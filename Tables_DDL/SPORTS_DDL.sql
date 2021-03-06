CREATE TABLE "DB626"."SPORTS" 
   (	"ID" NUMBER NOT NULL ENABLE, 
	"NAME" VARCHAR2(40 BYTE) NOT NULL ENABLE, 
	"CREATED_DT" DATE NOT NULL ENABLE, 
	"CREATED_BY" NUMBER NOT NULL ENABLE, 
	 CONSTRAINT "SPORTS_PK" PRIMARY KEY ("ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "STUDENTS"  ENABLE, 
	 CONSTRAINT "SPORTS_FK1" FOREIGN KEY ("CREATED_BY")
	  REFERENCES "DB626"."MANAGERS" ("ID") ENABLE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "STUDENTS" ;