CREATE DATABASE CodePersuit;
GO
USE CodePersuit;
GO
CREATE TABLE [User]
(
    UserId int NOT NULL IDENTITY (1,1),
    Username nvarchar(255) NOT NULL
);
GO
ALTER TABLE [User] ADD CONSTRAINT
    PK_User PRIMARY KEY CLUSTERED
    (
        UserId
    ) WITH(IGNORE_DUP_KEY=OFF);
GO
CREATE TABLE Repository
(
    RepositoryId int NOT NULL IDENTITY (1,1),
    Name varchar(255) NOT NULL,
    OwnerId int NOT NULL
);
GO
ALTER TABLE Repository ADD CONSTRAINT
    PK_Repository PRIMARY KEY CLUSTERED
    (
        RepositoryId
    ) WITH(IGNORE_DUP_KEY=OFF);
GO