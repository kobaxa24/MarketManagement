CREATE FUNCTION dbo.fn_DetectCircularReference
(
    @ParentID int,
    @CurrentID int
)
RETURNS bit
AS
BEGIN
    IF @ParentID IS NULL OR @CurrentID IS NULL
        RETURN 0;

    DECLARE @NextParentID int = @ParentID;
    DECLARE @PreviousID int;

    DECLARE @Visited TABLE
    (
        ID int NOT NULL PRIMARY KEY
    );

    WHILE @NextParentID IS NOT NULL
    BEGIN
        IF @NextParentID = @CurrentID
            RETURN 1;

        IF EXISTS
        (
            SELECT 1
            FROM @Visited
            WHERE ID = @NextParentID
        )
        RETURN 1;

        INSERT INTO @Visited (ID)
        VALUES (@NextParentID);

        SET @PreviousID = @NextParentID;
        SET @NextParentID = NULL;

        SELECT @NextParentID = c.ParentID
        FROM dbo.Categories c
        WHERE c.CategoryID = @PreviousID;
    END;

    RETURN 0;
END;