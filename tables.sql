CREATE TABLE Technology (
  id SERIAL PRIMARY KEY,
  technologyName VARCHAR(255),
  fileGuid VARCHAR(255),
  fileExtension VARCHAR(50),
  fileName VARCHAR(255),
  technologieUrl VARCHAR(255),
);

CREATE TABLE ProgrammingLanguage (
  id SERIAL PRIMARY KEY,
  technologyName VARCHAR(255),
  fileGuid VARCHAR(255),
  fileExtension VARCHAR(50),
  fileName VARCHAR(255),
  programmingLanguageUrl VARCHAR(255),
);

CREATE TABLE Tool (
  id SERIAL PRIMARY KEY,
  toolName VARCHAR(255),
  fileGuid VARCHAR(255),
  fileExtension VARCHAR(50),
  fileName VARCHAR(255),
  toolUrl VARCHAR(255),
);

CREATE TABLE Image (
  id SERIAL PRIMARY KEY,
  imageName VARCHAR(255),
  fileGuid VARCHAR(255),
  fileExtension VARCHAR(50),
  fileName VARCHAR(255),
  imageUrl VARCHAR(255),
);