CREATE TABLE "DB626"."TENNIS_PLAYERS" 
   (	"ID" NUMBER NOT NULL ENABLE, 
	"FIRST_NAME" VARCHAR2(100 BYTE) NOT NULL ENABLE, 
	"LAST_NAME" VARCHAR2(100 BYTE) NOT NULL ENABLE, 
	"COUNTRY" NUMBER NOT NULL ENABLE, 
	"NO_OF_GAMES" NUMBER NOT NULL ENABLE, 
	"WON" NUMBER NOT NULL ENABLE, 
	"LOST" NUMBER NOT NULL ENABLE, 
	"ACES" NUMBER NOT NULL ENABLE, 
	"SERVE_SPEED_MPH" NUMBER NOT NULL ENABLE, 
	"DOUBLE_FAULTS" NUMBER NOT NULL ENABLE, 
	"FSRP" NUMBER NOT NULL ENABLE, 
	"SSRP" NUMBER NOT NULL ENABLE, 
	"BPW" NUMBER NOT NULL ENABLE, 
	"LRC" NUMBER NOT NULL ENABLE, 
	"CREATED_BY" NUMBER NOT NULL ENABLE, 
	"CREATED_DT" TIMESTAMP (6) NOT NULL ENABLE, 
	"UPDATED_BY" NUMBER, 
	"UPDATED_DT" TIMESTAMP (6), 
	 CONSTRAINT "TENNIS_PLAYERS_PK" PRIMARY KEY ("ID")
  USING INDEX (CREATE UNIQUE INDEX "DB626"."TABLE1_PK" ON "DB626"."TENNIS_PLAYERS" ("ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "STUDENTS" )  ENABLE, 
	 CONSTRAINT "TENNIS_PLAYERS_FK1" FOREIGN KEY ("CREATED_BY")
	  REFERENCES "DB626"."AGENTS" ("ID") ENABLE, 
	 CONSTRAINT "TENNIS_PLAYERS_FK2" FOREIGN KEY ("UPDATED_BY")
	  REFERENCES "DB626"."AGENTS" ("ID") ENABLE, 
	 CONSTRAINT "TENNIS_PLAYERS_FK3" FOREIGN KEY ("COUNTRY")
	  REFERENCES "DB626"."COUNTRIES" ("ID") ENABLE
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "STUDENTS" ;