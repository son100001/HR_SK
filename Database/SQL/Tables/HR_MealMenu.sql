CREATE TABLE [dbo].[HR_MealMenu] (
    [Fromdate] DATETIME NOT NULL,
    [Todate] DATETIME NOT NULL,
    [Picture] IMAGE NULL
);

ALTER TABLE [dbo].[HR_MealMenu] ADD CONSTRAINT [PK_HR_MealMenu] PRIMARY KEY ([Fromdate] ASC);
