CREATE TABLE "DB626"."BASKETBALL_PLAYERS" 
   (	"ID" NUMBER NOT NULL ENABLE, 
	"FIRST_NAME" VARCHAR2(100 BYTE) NOT NULL ENABLE, 
	"LAST_NAME" VARCHAR2(100 BYTE) NOT NULL ENABLE, 
	"COUNTRY" NUMBER NOT NULL ENABLE, 
	"GAMES_PLAYED" NUMBER NOT NULL ENABLE, 
	"MINUTES_PLAYED" NUMBER NOT NULL ENABLE, 
	"FIELD_GOALS_MADE" NUMBER NOT NULL ENABLE, 
	"FIELD_GOALS_ATTEMPTED" NUMBER NOT NULL ENABLE, 
	"THREE_PM" NUMBER NOT NULL ENABLE, 
	"THREE_PA" NUMBER NOT NULL ENABLE, 
	"FREE_THROWS_MADE" NUMBER NOT NULL ENABLE, 
	"FREE_THROWS_ATTEMPTED" NUMBER NOT NULL ENABLE, 
	"TURNOVERS" NUMBER NOT NULL ENABLE, 
	"PERSONAL_FOULS" NUMBER NOT NULL ENABLE, 
	"OFFENSIVE_REBOUNDS" NUMBER NOT NULL ENABLE, 
	"DEFENSIVE_REBOUNDS" NUMBER NOT NULL ENABLE, 
	"CREATED_BY" NUMBER NOT NULL ENABLE, 
	"CREATED_DT" TIMESTAMP (6) NOT NULL ENABLE, 
	"UPDATED_BY" NUMBER, 
	"UPDATED_DT" TIMESTAMP (6), 
	 CONSTRAINT "BASKETBALL_PLAYERS_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "STUDENTS"  ENABLE, 
	 CONSTRAINT "BASKETBALL_PLAYERS_FK2" FOREIGN KEY ("COUNTRY")
	  REFERENCES "DB626"."COUNTRIES" ("ID") ENABLE, 
	 CONSTRAINT "BASKETBALL_PLAYERS_FK1" FOREIGN KEY ("CREATED_BY")
	  REFERENCES "DB626"."AGENTS" ("ID") ENABLE, 
	 CONSTRAINT "BASKETBALL_PLAYERS_FK3" FOREIGN KEY ("UPDATED_BY")
	  REFERENCES "DB626"."AGENTS" ("ID") ENABLE
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "STUDENTS" ;