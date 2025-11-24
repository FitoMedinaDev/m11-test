USE [products];
GO

PRINT '== Seeding DocumentTypes ==';
IF NOT EXISTS (SELECT 1 FROM DocumentTypes)
BEGIN
INSERT INTO DocumentTypes (Code, Name, CreatedAt)
VALUES
    ('CI', 'Carnet de Identidad', GETUTCDATE()),
    ('NIT', 'Número de Identificación Tributaria', GETUTCDATE());
END
GO

PRINT '== Seeding Clients ==';
IF NOT EXISTS (SELECT 1 FROM Clients)
BEGIN
INSERT INTO Clients (Code, Name, Email, DocumentNumber, DocumentTypeId, CreatedAt, UpdatedAt, DeletedAt)
VALUES
    ('C001', 'Pedro Gutierrez', 'pedro.gutierrez@gmail.com', 12345678, (SELECT id FROM DocumentTypes WHERE Code = 'CI'), GETUTCDATE(), NULL, NULL);
END
GO