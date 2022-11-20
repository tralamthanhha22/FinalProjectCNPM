
create database SE_FinalProject

use SE_FinalProject

/*==============================================================*/
/* DBMS name:      SAP SQL Anywhere 17                          */
/* Created on:     11/20/2022 7:39:49 PM               
*/
/*==============================================================*/


/*==============================================================*/
/* Table: ACCOUNTANT                                            */
/*==============================================================*/
create  table ACCOUNTANT 
(
   ACCOUNTID            varchar(5)                     not null,
   AGENTNAME            varchar(50)                    null,
   AGENTPHONE           varchar(10)                    null,
   AGENTADDRESS         varchar(100)                   null,
   constraint PK_ACCOUNTANT primary key clustered (ACCOUNTID)
);



/*==============================================================*/
/* Table: AGENT                                                 */
/*==============================================================*/
create table AGENT 
(
   AGENTID              varchar(5)                     not null,
   AGENTNAME            varchar(50)                    null,
   AGENTADDRESS         varchar(100)                   null,
   AGENTEMAIL           varchar(50)                    null,
   AGENTPHONE           varchar(10)                    null,
   constraint PK_AGENT primary key clustered (AGENTID)
);


/*==============================================================*/
/* Table: DELIVERY                                              */
/*==============================================================*/
create table DELIVERY 
(
   DELIVERYNOTE_ID      varchar(5)                     not null,
   DELIVERYNAME         varchar(50)                    null,
   DELIVERYFEE          numeric(8,2)                   null,
   constraint PK_DELIVERY primary key (DELIVERYNOTE_ID)
);


/*==============================================================*/
/* Table: IMPORT                                                */
/*==============================================================*/
create table IMPORT 
(
   IMPORTID             varchar(5)                     not null,
   ACCOUNTID            varchar(5)                     null,
   IMPORTDATE           timestamp                      null,
   constraint PK_IMPORT primary key clustered (IMPORTID)
);



/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_3_FK on IMPORT (
ACCOUNTID ASC
);

/*==============================================================*/
/* Table: IMPORT_DETAIL                                         */
/*==============================================================*/
create  table IMPORT_DETAIL 
(
   IDETAIL_ID           varchar(5)                     not null,
   PRODUCTID            varchar(5)                     null,
   IMPORTID             varchar(5)                     null,
   IMPORTQUANTITY       integer                        null,
   constraint PK_IMPORT_DETAIL primary key clustered (IDETAIL_ID)
);


/*==============================================================*/
/* Index: RELATIONSHIP_6_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_6_FK on IMPORT_DETAIL (
PRODUCTID ASC
);

/*==============================================================*/
/* Index: RELATIONSHIP_8_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_8_FK on IMPORT_DETAIL (
IMPORTID ASC
);

/*==============================================================*/
/* Table: "ORDER"                                               */
/*==============================================================*/
create  table "ORDER" 
(
   ORDERID              varchar(5)                     not null,
   AGENTID              varchar(5)                     null,
   DELIVERYNOTE_ID      varchar(5)                     null,
   ORDERDATE            date                           null,
   ORDERSTATUS          varchar(10)                    null,
   PAYMENTSTATUS        varchar(10)                    null,
   PAYMENTMETHOD        varchar(10)                    null,
   constraint PK_ORDER primary key clustered (ORDERID)
);

/*==============================================================*/
/* Index: RELATIONSHIP_4_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_4_FK on "ORDER" (
AGENTID ASC
);

/*==============================================================*/
/* Index: RELATIONSHIP_9_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_9_FK on "ORDER" (
DELIVERYNOTE_ID ASC
);

/*==============================================================*/
/* Table: ORDER_DETAIL                                          */
/*==============================================================*/
create table ORDER_DETAIL 
(
   ODETAIL_ID           varchar(5)                     not null,
   ORDERID              varchar(5)                     null,
   PRODUCTID            varchar(5)                     null,
   BUYQUANTITY          integer                        null,
   constraint PK_ORDER_DETAIL primary key clustered (ODETAIL_ID)
);


/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_2_FK on ORDER_DETAIL (
ORDERID ASC
);

/*==============================================================*/
/* Index: RELATIONSHIP_7_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_7_FK on ORDER_DETAIL (
PRODUCTID ASC
);

/*==============================================================*/
/* Table: PRODUCT                                               */
/*==============================================================*/
create  table PRODUCT 
(
   PRODUCTID            varchar(5)                     not null,
   PRONAME              varchar(50)                    null,
   PROPRICE             numeric(8,2)                   null,
   PROORIGIN            varchar(10)                    null,
   PROQUANTITY          integer                        null,
   PROTYPE              varchar(10)                    null,
   PROBRAND             varchar(20)                    null,
   PRODESCRIPTION       varchar(100)                   null,
   USEDATE              date                           null,
   HASSOLD              integer                        null,
   constraint PK_PRODUCT primary key clustered (PRODUCTID)
);



alter table IMPORT
   add constraint FK_IMPORT_RELATIONS_ACCOUNTA foreign key (ACCOUNTID)
      references ACCOUNTANT (ACCOUNTID)


alter table IMPORT_DETAIL
   add constraint FK_IMPORT_D_RELATIONS_PRODUCT foreign key (PRODUCTID)
      references PRODUCT (PRODUCTID)

alter table IMPORT_DETAIL
   add constraint FK_IMPORT_D_RELATIONS_IMPORT foreign key (IMPORTID)
      references IMPORT (IMPORTID)
     
alter table "ORDER"
   add constraint FK_ORDER_RELATIONS_AGENT foreign key (AGENTID)
      references AGENT (AGENTID)

alter table "ORDER"
   add constraint FK_ORDER_RELATIONS_DELIVERY foreign key (DELIVERYNOTE_ID)
      references DELIVERY (DELIVERYNOTE_ID)

alter table ORDER_DETAIL
   add constraint FK_ORDER_DE_RELATIONS_ORDER foreign key (ORDERID)
      references "ORDER" (ORDERID)

alter table ORDER_DETAIL
   add constraint FK_ORDER_DE_RELATIONS_PRODUCT foreign key (PRODUCTID)
      references PRODUCT (PRODUCTID)



/*==============================================================*/
/* Part :      Insert in database	                            */
/* Created on:     11/20/2022 7:39:49 PM						*/
/*==============================================================*/

