
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 07/19/2011 23:11:35
-- Generated from EDMX file: c:\Dev\Homeschool\HSTracker\Hst.DataAccess\Hst.DataAccess\HstDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HST.DB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ChildUser_Child]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChildUser] DROP CONSTRAINT [FK_ChildUser_Child];
GO
IF OBJECT_ID(N'[dbo].[FK_ChildUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChildUser] DROP CONSTRAINT [FK_ChildUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectStateRequiredSubject_Subject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubjectStateRequiredSubject] DROP CONSTRAINT [FK_SubjectStateRequiredSubject_Subject];
GO
IF OBJECT_ID(N'[dbo].[FK_SubjectStateRequiredSubject_StateRequiredSubject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubjectStateRequiredSubject] DROP CONSTRAINT [FK_SubjectStateRequiredSubject_StateRequiredSubject];
GO
IF OBJECT_ID(N'[dbo].[FK_ChildLesson_Child]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChildLesson] DROP CONSTRAINT [FK_ChildLesson_Child];
GO
IF OBJECT_ID(N'[dbo].[FK_ChildLesson_Lesson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChildLesson] DROP CONSTRAINT [FK_ChildLesson_Lesson];
GO
IF OBJECT_ID(N'[dbo].[FK_UserLesson_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserLesson] DROP CONSTRAINT [FK_UserLesson_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserLesson_Lesson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserLesson] DROP CONSTRAINT [FK_UserLesson_Lesson];
GO
IF OBJECT_ID(N'[dbo].[FK_LessonSubject_Lesson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LessonSubject] DROP CONSTRAINT [FK_LessonSubject_Lesson];
GO
IF OBJECT_ID(N'[dbo].[FK_LessonSubject_Subject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LessonSubject] DROP CONSTRAINT [FK_LessonSubject_Subject];
GO
IF OBJECT_ID(N'[dbo].[FK_ChildActivity_Child]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChildActivity] DROP CONSTRAINT [FK_ChildActivity_Child];
GO
IF OBJECT_ID(N'[dbo].[FK_ChildActivity_Activity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChildActivity] DROP CONSTRAINT [FK_ChildActivity_Activity];
GO
IF OBJECT_ID(N'[dbo].[FK_UserActivity_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserActivity] DROP CONSTRAINT [FK_UserActivity_User];
GO
IF OBJECT_ID(N'[dbo].[FK_UserActivity_Activity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserActivity] DROP CONSTRAINT [FK_UserActivity_Activity];
GO
IF OBJECT_ID(N'[dbo].[FK_ActivitySubject_Activity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActivitySubject] DROP CONSTRAINT [FK_ActivitySubject_Activity];
GO
IF OBJECT_ID(N'[dbo].[FK_ActivitySubject_Subject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActivitySubject] DROP CONSTRAINT [FK_ActivitySubject_Subject];
GO
IF OBJECT_ID(N'[dbo].[FK_Test_TestResult_Test]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Test_TestResult] DROP CONSTRAINT [FK_Test_TestResult_Test];
GO
IF OBJECT_ID(N'[dbo].[FK_Test_TestResult_TestResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Test_TestResult] DROP CONSTRAINT [FK_Test_TestResult_TestResult];
GO
IF OBJECT_ID(N'[dbo].[FK_ChildTestResult_Child]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChildTestResult] DROP CONSTRAINT [FK_ChildTestResult_Child];
GO
IF OBJECT_ID(N'[dbo].[FK_ChildTestResult_TestResult]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChildTestResult] DROP CONSTRAINT [FK_ChildTestResult_TestResult];
GO
IF OBJECT_ID(N'[dbo].[FK_TestUser_Test]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestUser] DROP CONSTRAINT [FK_TestUser_Test];
GO
IF OBJECT_ID(N'[dbo].[FK_TestUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestUser] DROP CONSTRAINT [FK_TestUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_ChildSchool]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Children] DROP CONSTRAINT [FK_ChildSchool];
GO
IF OBJECT_ID(N'[dbo].[FK_UserSchool]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserSchool];
GO
IF OBJECT_ID(N'[dbo].[FK_TestSubject_Test]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestSubject] DROP CONSTRAINT [FK_TestSubject_Test];
GO
IF OBJECT_ID(N'[dbo].[FK_TestSubject_Subject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestSubject] DROP CONSTRAINT [FK_TestSubject_Subject];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Children]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Children];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[StateRequiredSubjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StateRequiredSubjects];
GO
IF OBJECT_ID(N'[dbo].[Subjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subjects];
GO
IF OBJECT_ID(N'[dbo].[Lessons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Lessons];
GO
IF OBJECT_ID(N'[dbo].[Activities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activities];
GO
IF OBJECT_ID(N'[dbo].[Tests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tests];
GO
IF OBJECT_ID(N'[dbo].[TestResults]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestResults];
GO
IF OBJECT_ID(N'[dbo].[Schools]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Schools];
GO
IF OBJECT_ID(N'[dbo].[ChildUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChildUser];
GO
IF OBJECT_ID(N'[dbo].[SubjectStateRequiredSubject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubjectStateRequiredSubject];
GO
IF OBJECT_ID(N'[dbo].[ChildLesson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChildLesson];
GO
IF OBJECT_ID(N'[dbo].[UserLesson]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserLesson];
GO
IF OBJECT_ID(N'[dbo].[LessonSubject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LessonSubject];
GO
IF OBJECT_ID(N'[dbo].[ChildActivity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChildActivity];
GO
IF OBJECT_ID(N'[dbo].[UserActivity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserActivity];
GO
IF OBJECT_ID(N'[dbo].[ActivitySubject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActivitySubject];
GO
IF OBJECT_ID(N'[dbo].[Test_TestResult]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Test_TestResult];
GO
IF OBJECT_ID(N'[dbo].[ChildTestResult]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChildTestResult];
GO
IF OBJECT_ID(N'[dbo].[TestUser]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestUser];
GO
IF OBJECT_ID(N'[dbo].[TestSubject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestSubject];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Children'
CREATE TABLE [dbo].[Children] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameFirst] nvarchar(max)  NOT NULL,
    [NameLast] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [SchoolId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [NameFirst] nvarchar(max)  NOT NULL,
    [NameLast] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [IsTeacher] bit  NOT NULL,
    [SchoolId] int  NULL
);
GO

-- Creating table 'StateRequiredSubjects'
CREATE TABLE [dbo].[StateRequiredSubjects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Subjects'
CREATE TABLE [dbo].[Subjects] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Lessons'
CREATE TABLE [dbo].[Lessons] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LessonTitle] nvarchar(max)  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [LessonDate] datetime  NOT NULL,
    [TimeSpent] time  NOT NULL
);
GO

-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActivityName] nvarchar(max)  NOT NULL,
    [ActivityDate] datetime  NOT NULL,
    [Notes] nvarchar(max)  NOT NULL,
    [TimeSpent] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tests'
CREATE TABLE [dbo].[Tests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TestName] nvarchar(max)  NOT NULL,
    [Questions] int  NOT NULL,
    [TestDate] datetime  NOT NULL
);
GO

-- Creating table 'TestResults'
CREATE TABLE [dbo].[TestResults] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Correct] int  NOT NULL,
    [NotAnswered] int  NOT NULL,
    [Incorrect] int  NOT NULL
);
GO

-- Creating table 'Schools'
CREATE TABLE [dbo].[Schools] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SchoolName] nvarchar(max)  NOT NULL,
    [DateJoined] datetime  NOT NULL
);
GO

-- Creating table 'ChildUser'
CREATE TABLE [dbo].[ChildUser] (
    [Children_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
);
GO

-- Creating table 'SubjectStateRequiredSubject'
CREATE TABLE [dbo].[SubjectStateRequiredSubject] (
    [Subjects_Id] int  NOT NULL,
    [StateRequiredSubjects_Id] int  NOT NULL
);
GO

-- Creating table 'ChildLesson'
CREATE TABLE [dbo].[ChildLesson] (
    [Children_Id] int  NOT NULL,
    [Lessons_Id] int  NOT NULL
);
GO

-- Creating table 'UserLesson'
CREATE TABLE [dbo].[UserLesson] (
    [Users_Id] int  NOT NULL,
    [Lessons_Id] int  NOT NULL
);
GO

-- Creating table 'LessonSubject'
CREATE TABLE [dbo].[LessonSubject] (
    [Lessons_Id] int  NOT NULL,
    [Subjects_Id] int  NOT NULL
);
GO

-- Creating table 'ChildActivity'
CREATE TABLE [dbo].[ChildActivity] (
    [Children_Id] int  NOT NULL,
    [Activities_Id] int  NOT NULL
);
GO

-- Creating table 'UserActivity'
CREATE TABLE [dbo].[UserActivity] (
    [Users_Id] int  NOT NULL,
    [Activities_Id] int  NOT NULL
);
GO

-- Creating table 'ActivitySubject'
CREATE TABLE [dbo].[ActivitySubject] (
    [Activities_Id] int  NOT NULL,
    [Subjects_Id] int  NOT NULL
);
GO

-- Creating table 'Test_TestResult'
CREATE TABLE [dbo].[Test_TestResult] (
    [Tests_Id] int  NOT NULL,
    [TestResults_Id] int  NOT NULL
);
GO

-- Creating table 'ChildTestResult'
CREATE TABLE [dbo].[ChildTestResult] (
    [Children_Id] int  NOT NULL,
    [TestResults_Id] int  NOT NULL
);
GO

-- Creating table 'TestUser'
CREATE TABLE [dbo].[TestUser] (
    [Tests_Id] int  NOT NULL,
    [Users_Id] int  NOT NULL
);
GO

-- Creating table 'TestSubject'
CREATE TABLE [dbo].[TestSubject] (
    [Tests_Id] int  NOT NULL,
    [Subjects_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Children'
ALTER TABLE [dbo].[Children]
ADD CONSTRAINT [PK_Children]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'StateRequiredSubjects'
ALTER TABLE [dbo].[StateRequiredSubjects]
ADD CONSTRAINT [PK_StateRequiredSubjects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Subjects'
ALTER TABLE [dbo].[Subjects]
ADD CONSTRAINT [PK_Subjects]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Lessons'
ALTER TABLE [dbo].[Lessons]
ADD CONSTRAINT [PK_Lessons]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tests'
ALTER TABLE [dbo].[Tests]
ADD CONSTRAINT [PK_Tests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TestResults'
ALTER TABLE [dbo].[TestResults]
ADD CONSTRAINT [PK_TestResults]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Schools'
ALTER TABLE [dbo].[Schools]
ADD CONSTRAINT [PK_Schools]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Children_Id], [Users_Id] in table 'ChildUser'
ALTER TABLE [dbo].[ChildUser]
ADD CONSTRAINT [PK_ChildUser]
    PRIMARY KEY NONCLUSTERED ([Children_Id], [Users_Id] ASC);
GO

-- Creating primary key on [Subjects_Id], [StateRequiredSubjects_Id] in table 'SubjectStateRequiredSubject'
ALTER TABLE [dbo].[SubjectStateRequiredSubject]
ADD CONSTRAINT [PK_SubjectStateRequiredSubject]
    PRIMARY KEY NONCLUSTERED ([Subjects_Id], [StateRequiredSubjects_Id] ASC);
GO

-- Creating primary key on [Children_Id], [Lessons_Id] in table 'ChildLesson'
ALTER TABLE [dbo].[ChildLesson]
ADD CONSTRAINT [PK_ChildLesson]
    PRIMARY KEY NONCLUSTERED ([Children_Id], [Lessons_Id] ASC);
GO

-- Creating primary key on [Users_Id], [Lessons_Id] in table 'UserLesson'
ALTER TABLE [dbo].[UserLesson]
ADD CONSTRAINT [PK_UserLesson]
    PRIMARY KEY NONCLUSTERED ([Users_Id], [Lessons_Id] ASC);
GO

-- Creating primary key on [Lessons_Id], [Subjects_Id] in table 'LessonSubject'
ALTER TABLE [dbo].[LessonSubject]
ADD CONSTRAINT [PK_LessonSubject]
    PRIMARY KEY NONCLUSTERED ([Lessons_Id], [Subjects_Id] ASC);
GO

-- Creating primary key on [Children_Id], [Activities_Id] in table 'ChildActivity'
ALTER TABLE [dbo].[ChildActivity]
ADD CONSTRAINT [PK_ChildActivity]
    PRIMARY KEY NONCLUSTERED ([Children_Id], [Activities_Id] ASC);
GO

-- Creating primary key on [Users_Id], [Activities_Id] in table 'UserActivity'
ALTER TABLE [dbo].[UserActivity]
ADD CONSTRAINT [PK_UserActivity]
    PRIMARY KEY NONCLUSTERED ([Users_Id], [Activities_Id] ASC);
GO

-- Creating primary key on [Activities_Id], [Subjects_Id] in table 'ActivitySubject'
ALTER TABLE [dbo].[ActivitySubject]
ADD CONSTRAINT [PK_ActivitySubject]
    PRIMARY KEY NONCLUSTERED ([Activities_Id], [Subjects_Id] ASC);
GO

-- Creating primary key on [Tests_Id], [TestResults_Id] in table 'Test_TestResult'
ALTER TABLE [dbo].[Test_TestResult]
ADD CONSTRAINT [PK_Test_TestResult]
    PRIMARY KEY NONCLUSTERED ([Tests_Id], [TestResults_Id] ASC);
GO

-- Creating primary key on [Children_Id], [TestResults_Id] in table 'ChildTestResult'
ALTER TABLE [dbo].[ChildTestResult]
ADD CONSTRAINT [PK_ChildTestResult]
    PRIMARY KEY NONCLUSTERED ([Children_Id], [TestResults_Id] ASC);
GO

-- Creating primary key on [Tests_Id], [Users_Id] in table 'TestUser'
ALTER TABLE [dbo].[TestUser]
ADD CONSTRAINT [PK_TestUser]
    PRIMARY KEY NONCLUSTERED ([Tests_Id], [Users_Id] ASC);
GO

-- Creating primary key on [Tests_Id], [Subjects_Id] in table 'TestSubject'
ALTER TABLE [dbo].[TestSubject]
ADD CONSTRAINT [PK_TestSubject]
    PRIMARY KEY NONCLUSTERED ([Tests_Id], [Subjects_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Children_Id] in table 'ChildUser'
ALTER TABLE [dbo].[ChildUser]
ADD CONSTRAINT [FK_ChildUser_Child]
    FOREIGN KEY ([Children_Id])
    REFERENCES [dbo].[Children]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'ChildUser'
ALTER TABLE [dbo].[ChildUser]
ADD CONSTRAINT [FK_ChildUser_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChildUser_User'
CREATE INDEX [IX_FK_ChildUser_User]
ON [dbo].[ChildUser]
    ([Users_Id]);
GO

-- Creating foreign key on [Subjects_Id] in table 'SubjectStateRequiredSubject'
ALTER TABLE [dbo].[SubjectStateRequiredSubject]
ADD CONSTRAINT [FK_SubjectStateRequiredSubject_Subject]
    FOREIGN KEY ([Subjects_Id])
    REFERENCES [dbo].[Subjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [StateRequiredSubjects_Id] in table 'SubjectStateRequiredSubject'
ALTER TABLE [dbo].[SubjectStateRequiredSubject]
ADD CONSTRAINT [FK_SubjectStateRequiredSubject_StateRequiredSubject]
    FOREIGN KEY ([StateRequiredSubjects_Id])
    REFERENCES [dbo].[StateRequiredSubjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SubjectStateRequiredSubject_StateRequiredSubject'
CREATE INDEX [IX_FK_SubjectStateRequiredSubject_StateRequiredSubject]
ON [dbo].[SubjectStateRequiredSubject]
    ([StateRequiredSubjects_Id]);
GO

-- Creating foreign key on [Children_Id] in table 'ChildLesson'
ALTER TABLE [dbo].[ChildLesson]
ADD CONSTRAINT [FK_ChildLesson_Child]
    FOREIGN KEY ([Children_Id])
    REFERENCES [dbo].[Children]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Lessons_Id] in table 'ChildLesson'
ALTER TABLE [dbo].[ChildLesson]
ADD CONSTRAINT [FK_ChildLesson_Lesson]
    FOREIGN KEY ([Lessons_Id])
    REFERENCES [dbo].[Lessons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChildLesson_Lesson'
CREATE INDEX [IX_FK_ChildLesson_Lesson]
ON [dbo].[ChildLesson]
    ([Lessons_Id]);
GO

-- Creating foreign key on [Users_Id] in table 'UserLesson'
ALTER TABLE [dbo].[UserLesson]
ADD CONSTRAINT [FK_UserLesson_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Lessons_Id] in table 'UserLesson'
ALTER TABLE [dbo].[UserLesson]
ADD CONSTRAINT [FK_UserLesson_Lesson]
    FOREIGN KEY ([Lessons_Id])
    REFERENCES [dbo].[Lessons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLesson_Lesson'
CREATE INDEX [IX_FK_UserLesson_Lesson]
ON [dbo].[UserLesson]
    ([Lessons_Id]);
GO

-- Creating foreign key on [Lessons_Id] in table 'LessonSubject'
ALTER TABLE [dbo].[LessonSubject]
ADD CONSTRAINT [FK_LessonSubject_Lesson]
    FOREIGN KEY ([Lessons_Id])
    REFERENCES [dbo].[Lessons]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Subjects_Id] in table 'LessonSubject'
ALTER TABLE [dbo].[LessonSubject]
ADD CONSTRAINT [FK_LessonSubject_Subject]
    FOREIGN KEY ([Subjects_Id])
    REFERENCES [dbo].[Subjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LessonSubject_Subject'
CREATE INDEX [IX_FK_LessonSubject_Subject]
ON [dbo].[LessonSubject]
    ([Subjects_Id]);
GO

-- Creating foreign key on [Children_Id] in table 'ChildActivity'
ALTER TABLE [dbo].[ChildActivity]
ADD CONSTRAINT [FK_ChildActivity_Child]
    FOREIGN KEY ([Children_Id])
    REFERENCES [dbo].[Children]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Activities_Id] in table 'ChildActivity'
ALTER TABLE [dbo].[ChildActivity]
ADD CONSTRAINT [FK_ChildActivity_Activity]
    FOREIGN KEY ([Activities_Id])
    REFERENCES [dbo].[Activities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChildActivity_Activity'
CREATE INDEX [IX_FK_ChildActivity_Activity]
ON [dbo].[ChildActivity]
    ([Activities_Id]);
GO

-- Creating foreign key on [Users_Id] in table 'UserActivity'
ALTER TABLE [dbo].[UserActivity]
ADD CONSTRAINT [FK_UserActivity_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Activities_Id] in table 'UserActivity'
ALTER TABLE [dbo].[UserActivity]
ADD CONSTRAINT [FK_UserActivity_Activity]
    FOREIGN KEY ([Activities_Id])
    REFERENCES [dbo].[Activities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserActivity_Activity'
CREATE INDEX [IX_FK_UserActivity_Activity]
ON [dbo].[UserActivity]
    ([Activities_Id]);
GO

-- Creating foreign key on [Activities_Id] in table 'ActivitySubject'
ALTER TABLE [dbo].[ActivitySubject]
ADD CONSTRAINT [FK_ActivitySubject_Activity]
    FOREIGN KEY ([Activities_Id])
    REFERENCES [dbo].[Activities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Subjects_Id] in table 'ActivitySubject'
ALTER TABLE [dbo].[ActivitySubject]
ADD CONSTRAINT [FK_ActivitySubject_Subject]
    FOREIGN KEY ([Subjects_Id])
    REFERENCES [dbo].[Subjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivitySubject_Subject'
CREATE INDEX [IX_FK_ActivitySubject_Subject]
ON [dbo].[ActivitySubject]
    ([Subjects_Id]);
GO

-- Creating foreign key on [Tests_Id] in table 'Test_TestResult'
ALTER TABLE [dbo].[Test_TestResult]
ADD CONSTRAINT [FK_Test_TestResult_Test]
    FOREIGN KEY ([Tests_Id])
    REFERENCES [dbo].[Tests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TestResults_Id] in table 'Test_TestResult'
ALTER TABLE [dbo].[Test_TestResult]
ADD CONSTRAINT [FK_Test_TestResult_TestResult]
    FOREIGN KEY ([TestResults_Id])
    REFERENCES [dbo].[TestResults]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Test_TestResult_TestResult'
CREATE INDEX [IX_FK_Test_TestResult_TestResult]
ON [dbo].[Test_TestResult]
    ([TestResults_Id]);
GO

-- Creating foreign key on [Children_Id] in table 'ChildTestResult'
ALTER TABLE [dbo].[ChildTestResult]
ADD CONSTRAINT [FK_ChildTestResult_Child]
    FOREIGN KEY ([Children_Id])
    REFERENCES [dbo].[Children]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TestResults_Id] in table 'ChildTestResult'
ALTER TABLE [dbo].[ChildTestResult]
ADD CONSTRAINT [FK_ChildTestResult_TestResult]
    FOREIGN KEY ([TestResults_Id])
    REFERENCES [dbo].[TestResults]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChildTestResult_TestResult'
CREATE INDEX [IX_FK_ChildTestResult_TestResult]
ON [dbo].[ChildTestResult]
    ([TestResults_Id]);
GO

-- Creating foreign key on [Tests_Id] in table 'TestUser'
ALTER TABLE [dbo].[TestUser]
ADD CONSTRAINT [FK_TestUser_Test]
    FOREIGN KEY ([Tests_Id])
    REFERENCES [dbo].[Tests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Users_Id] in table 'TestUser'
ALTER TABLE [dbo].[TestUser]
ADD CONSTRAINT [FK_TestUser_User]
    FOREIGN KEY ([Users_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TestUser_User'
CREATE INDEX [IX_FK_TestUser_User]
ON [dbo].[TestUser]
    ([Users_Id]);
GO

-- Creating foreign key on [SchoolId] in table 'Children'
ALTER TABLE [dbo].[Children]
ADD CONSTRAINT [FK_ChildSchool]
    FOREIGN KEY ([SchoolId])
    REFERENCES [dbo].[Schools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChildSchool'
CREATE INDEX [IX_FK_ChildSchool]
ON [dbo].[Children]
    ([SchoolId]);
GO

-- Creating foreign key on [SchoolId] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_UserSchool]
    FOREIGN KEY ([SchoolId])
    REFERENCES [dbo].[Schools]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserSchool'
CREATE INDEX [IX_FK_UserSchool]
ON [dbo].[Users]
    ([SchoolId]);
GO

-- Creating foreign key on [Tests_Id] in table 'TestSubject'
ALTER TABLE [dbo].[TestSubject]
ADD CONSTRAINT [FK_TestSubject_Test]
    FOREIGN KEY ([Tests_Id])
    REFERENCES [dbo].[Tests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Subjects_Id] in table 'TestSubject'
ALTER TABLE [dbo].[TestSubject]
ADD CONSTRAINT [FK_TestSubject_Subject]
    FOREIGN KEY ([Subjects_Id])
    REFERENCES [dbo].[Subjects]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TestSubject_Subject'
CREATE INDEX [IX_FK_TestSubject_Subject]
ON [dbo].[TestSubject]
    ([Subjects_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------