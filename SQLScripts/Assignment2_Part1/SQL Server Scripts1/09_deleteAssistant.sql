USE SuperheroesDb;

-- Delete an assistant by name
DECLARE @AssistantName nvarchar(50)
SET @AssistantName = 'Kid Flash'; -- Change to the name of the assistant you want to delete

-- Check if the assistant exists
IF EXISTS (SELECT 1 FROM Assistant WHERE [Name] = @AssistantName)
BEGIN
    -- Delete the assistant
    DELETE FROM Assistant WHERE [Name] = @AssistantName;
    PRINT 'Assistant ' + @AssistantName + ' has been deleted.';
END
ELSE
BEGIN
    PRINT 'Assistant ' + @AssistantName + ' does not exist.';
END
