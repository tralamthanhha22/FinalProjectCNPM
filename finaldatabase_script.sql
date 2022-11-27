
create database SE_FinalProject_DB

use SE_FinalProject_DB


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
   AGENTNAME            nvarchar(50)                    null,
   AGENTPHONE           varchar(10)                    null,
   AGENTADDRESS         nvarchar(100)                   null,
   constraint PK_ACCOUNTANT primary key clustered (ACCOUNTID)
);



/*==============================================================*/
/* Table: AGENT                                                 */
/*==============================================================*/
create table AGENT 
(
   AGENTID              varchar(5)                     not null,
   AGENTNAME            nvarchar(50)                    null,
   AGENTADDRESS         nvarchar(100)                   null,
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
   DELIVERYNAME         nvarchar(50)                    null,
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
   ORDERSTATUS          nvarchar(10)                    null,
   PAYMENTSTATUS        nvarchar(10)                    null,
   PAYMENTMETHOD        nvarchar(10)                    null,
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
   PRONAME              nvarchar(50)                    null,
   PROPRICE             numeric(8,2)                   null,
   PROORIGIN            nvarchar(10)                    null,
   PROQUANTITY          integer                        null,
   PROTYPE              nvarchar(10)                    null,
   PROBRAND             nvarchar(20)                    null,
   PRODESCRIPTION       nvarchar(100)                   null,
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


ALTER TABLE Product 
ALTER COLUMN PRODESCRIPTION NVARCHAR(400) 




/*==============================================================*/
/* Part :      Insert in database	                            */
/* Created on:     11/20/2022 7:39:49 PM						*/
/*==============================================================*/

/*==============================================================*/
/* Table: PRODUCT                                               */
/*==============================================================*/
delete from PRODUCT;
insert into PRODUCT values ('P0000',N'Tên sản phẩm', 0, N'Xuất xứ', 0, N'Type', N'Brand', N'Des', '2024-12-23',0);
insert into PRODUCT values ('P0001', N'Viên sủi Optimax Immunity Booster', 115000, N'Mỹ', 20, N'Đề kháng', N'INVAPHARM', N'Optimax Immunity Booster Vid-Fighter là sản phẩm tăng cường sức khỏe có tác dụng giảm căng thẳng và mệt mỏi, hỗ trợ chuyển hóa năng lượng và trao đổi chất, giúp nâng cao đề kháng và miễn dịch. Sản phẩm hạn chế cảm cúm, bệnh lây nhiễm, bảo vệ cho người bệnh mãn tính, đề kháng thấp, người lớn tuổi.', '2027-11-11',100);
insert into PRODUCT values ('P0002', N'Viên uống LiverWell Navi', 129000, N'Việt Nam', 20, N'Mát gan', N'TRƯỜNG THỌ', N'Với các thành phần thảo dược thiên nhiên lành tính giúp thanh lọc cơ thể, giải độc, mát gan, viên uống giải độc gan LiverWell hỗ trợ điều trị các bệnh viêm gan và tăng cường chức năng gan, mang đến cho bạn một lá gan khỏe mạnh.','2023-12-25',100);
insert into PRODUCT values ('P0003',N'Gói cốm Plus Kingphar', 25000, N'Việt Nam', 6, N'Mát gan', N'HERBITECH', N'Thanh Nhiệt Plus là sản phẩm của Công ty Cổ phần Kingphar Việt Nam. Đây là một trong những công ty tiên phong tại Việt Nam trong lĩnh vực chăm sóc sức khỏe cộng đồng bằng các sản phẩm có nguồn gốc dược liệu tự nhiên chọn lọc. Bên cạnh nền tảng kinh nghiệm cây thuốc từ dân gian', '2024-12-23',100);
insert into PRODUCT values ('P0004',N'Viên uống Active Legs New Nordic', 320000, N'Thụy Điển', 30, N'Tim mạch', N'LEGOSAN AB', N'Active Legs giúp tăng cường lưu thông tuần hoàn máu, tăng sức bền tĩnh mạch, hạn chế hình thành huyết khối, phòng ngừa và hỗ trợ điều trị suy giãn tĩnh mạch chân, giảm các triệu chứng đau chân, nặng chân, tê chân, gân xanh nổi ở chân…', '2025-12-23',100);
insert into PRODUCT values ('P0005',N'Viên uống Omexxel Cardio Excelife', 380000, N'Mỹ', 300, N'Tim mạch', N'EXCELIFE', N'Omexxel Cardio Excelife hỗ trợ tăng cường khả năng chống oxy hóa, giúp hạn chế xơ vữa động mạch, giúp duy trì sức khỏe tim mạch.', '2024-2-11',100);

select * from PRODUCT;

/*==============================================================*/
/* Table: DELIVERY                                              */
/*==============================================================*/

delete from DELIVERY;
insert into DELIVERY values('D0000', N'Miễn phí ship', 0);
insert into DELIVERY values('D0001', N'Grab nội thành', 20000);
insert into DELIVERY values('D0002', N'Grab ngoại thành', 30000);
insert into DELIVERY values('D0003', N'Giao hàng tiết kiệm nội thành', 10000);
insert into DELIVERY values('D0004', N'Giao hàng tiết kiệm ngoại thành', 20000);

select * from DELIVERY;