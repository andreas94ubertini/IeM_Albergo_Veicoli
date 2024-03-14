USE acc_Albergo;
--DROP TABLE IF EXISTS Cliente;
--DROP TABLE IF EXISTS Prenotazione;
--DROP TABLE IF EXISTS Facility;
--DROP TABLE IF EXISTS Dipendente;
--DROP TABLE IF EXISTS Camera;
--DROP TABLE IF EXISTS Albergo;
--CREATE TABLE Albergo(
--	albergoID INT PRIMARY KEY IDENTITY (1,1),
--	nome VARCHAR (150) NOT NULL,
--	indirizzo VARCHAR(150) UNIQUE NOT NULL,
--	valutazione TINYINT NOT NULL CHECK (valutazione > 0 AND valutazione < 6),
--);

--CREATE TABLE Camera(
--	cameraID INT PRIMARY KEY IDENTITY (1,1),
--	numero INT NOT NULL,
--	tipo VARCHAR (100) NOT NULL,
--	capacita INT NOT NULL,
--	tariffa DECIMAL (10,2),
--	albergoRIF INT NOT NULL,
--	FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE,
--	UNIQUE (albergoRIF, numero)
--);

--CREATE TABLE Cliente(
--	clienteID INT PRIMARY KEY IDENTITY (1,1),
--	nome VARCHAR(150) NOT NULL,
--	cognome VARCHAR (150) NOT NULL,
--	contatto VARCHAR (150) NOT NULL,
--);

--CREATE TABLE Prenotazione(
--	prenotazioneID INT PRIMARY KEY IDENTITY (1,1),
--	checkIn DATE NOT NULL,
--	checkOut DATE NOT NULL,
--	clienteRIF INT NOT NULL,
--	cameraRIF INT NOT NULL
--	FOREIGN KEY (clienteRIF) REFERENCES CLiente(clienteID) ON DELETE CASCADE,
--	FOREIGN KEY (cameraRIF) REFERENCES Camera(cameraID) ON DELETE CASCADE,
--	UNIQUE(checkIn, checkOut, cameraRIF)
--);

--CREATE TABLE Dipendente(
--	dipendenteID INT PRIMARY KEY IDENTITY (1,1),
--	nome VARCHAR (150) NOT NULL,
--	cognome VARCHAR (150) NOT NULL,
--	contatto VARCHAR (150) NOT NULL,
--	posizione VARCHAR (150) NOT NULL,
--	codFis CHAR(16) NOT NULL UNIQUE,
--	AlbergoRIF INT NOT NULL,
--	FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE,
--	UNIQUE(dipendenteID,AlbergoRIF)
--);

--CREATE TABLE Facility(
--	facilityID INT PRIMARY KEY IDENTITY (1,1),
--	nome VARCHAR (50) NOT NULL,
--	descrizione TEXT NOT NULL,
--	apertura TIME NOT NULL,
--	chiusura TIME NOT NULL,
--	albergoRIF INT NOT NULL,
--	FOREIGN KEY (albergoRIF) REFERENCES Albergo(albergoID) ON DELETE CASCADE,
--);

--INSERT INTO Albergo (nome, indirizzo, valutazione)
--VALUES
--    ('Hotel Roma', 'Via del Corso 123, Roma', 4),
--    ('Grand Hotel Colosseo', 'Piazza del Colosseo 1, Roma', 5),
--    ('Hotel Trastevere', 'Vicolo del Cinque 10, Roma', 3),
--    ('Hotel Pantheon', 'Piazza della Rotonda 6, Roma', 4),
--    ('Hotel Villa Borghese', 'Via Veneto 100, Roma', 4);

--INSERT INTO Camera (numero, tipo, capacita, tariffa, albergoRIF)
--VALUES
--    (101, 'Single', 1, 100.00, 1),
--    (102, 'Double', 2, 150.00, 1),
--    (103, 'Suite', 4, 300.00, 2),
--    (104, 'Twin', 2, 130.00, 2),
--    (105, 'Deluxe', 3, 220.00, 3);

--INSERT INTO Camera (numero, tipo, capacita, tariffa, albergoRIF)
--VALUES
--    (101, 'Single', 1, 100.00, 2);


--INSERT INTO Cliente (nome, cognome, contatto)
--VALUES
--    ('Alice', 'Smith', 'alice@example.com'),
--    ('Bob', 'Johnson', '+1 (555) 123-4567'),
--    ('Charlie', 'Brown', 'charlie@company.org'),
--    ('Diana', 'Lee', 'diana@gmail.com'),
--    ('Eva', 'Garcia', '+44 20 1234 5678');

--INSERT INTO Prenotazione (checkIn, checkOut, clienteRIF, cameraRIF)
--VALUES
--    ('2024-03-20', '2024-03-25', 1, 1),  -- Booking for client ID 1 in room ID 1
--    ('2024-04-10', '2024-04-15', 2, 2),  -- Booking for client ID 2 in room ID 2
--    ('2024-05-05', '2024-05-10', 3, 3),  -- Booking for client ID 3 in room ID 3
--    ('2024-06-15', '2024-06-20', 4, 4),  -- Booking for client ID 4 in room ID 4
--    ('2024-07-01', '2024-07-05', 5, 5);  -- Booking for client ID 5 in room ID 5

INSERT INTO Prenotazione (checkIn, checkOut, clienteRIF, cameraRIF)
VALUES
    ('2025-03-20', '2025-03-25', 2, 1);  -- Booking for client ID 1 in room ID 1

SELECT * FROM Prenotazione
DROP PROCEDURE IF EXISTS MakeReservation;
CREATE PROCEDURE MakeReservation
@checkIn DATE, 
@checkOut DATE, 
@clienteRIF INT, 
@cameraRIF INT
AS
BEGIN
	BEGIN TRY

		BEGIN TRANSACTION
			SELECT * FROM Prenotazione
			JOIN Camera ON Prenotazione.cameraRIF = Camera.cameraID
			WHERE Camera.cameraID = @cameraRIF AND @checkIn BETWEEN Prenotazione.checkIn AND Prenotazione.checkOut
			IF @@ROWCOUNT > 0
				THROW 50001, 'Camera non disponibile in tale data', 1
			INSERT INTO Prenotazione(checkIn, checkOut, clienteRIF, cameraRIF)
			VALUES(@checkIn,@checkOut,@clienteRIF,@cameraRIF)

			PRINT 'Prenotazione effettuata con successo'
		COMMIT TRANSACTION

	END TRY
	BEGIN CATCH

		ROLLBACK TRANSACTION

		PRINT 'Errore riscontrato: ' + ERROR_MESSAGE()

	END CATCH
END;
EXEC MakeReservation
@checkIn = '2024-03-24',
@checkOut = '2024-03-28',
@clienteRIF = 3,
@cameraRIF = 1

SELECT * FROM Prenotazione;

