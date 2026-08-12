CREATE TABLE [dbo].[HR_QuanHeGiaDinh] (
    [QuanHe] NVARCHAR(50) NOT NULL
);

ALTER TABLE [dbo].[HR_QuanHeGiaDinh] ADD CONSTRAINT [PK_HR_QuanHeGiaDinh] PRIMARY KEY ([QuanHe] ASC);
