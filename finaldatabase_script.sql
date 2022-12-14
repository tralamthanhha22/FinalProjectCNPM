
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
insert into PRODUCT values ('P0000',N'T??n s???n ph???m', 0, N'Xu???t x???', 0, N'Type', N'Brand', N'Des', '2024-12-23',0);
insert into PRODUCT values ('P0001', N'Vi??n s???i Optimax Immunity Booster', 115000, N'M???', 20, N'????? kh??ng', N'INVAPHARM', N'Optimax Immunity Booster Vid-Fighter l?? s???n ph???m t??ng c?????ng s???c kh???e c?? t??c d???ng gi???m c??ng th???ng v?? m???t m???i, h??? tr??? chuy???n h??a n??ng l?????ng v?? trao ?????i ch???t, gi??p n??ng cao ????? kh??ng v?? mi???n d???ch. S???n ph???m h???n ch??? c???m c??m, b???nh l??y nhi???m, b???o v??? cho ng?????i b???nh m??n t??nh, ????? kh??ng th???p, ng?????i l???n tu???i.', '2027-11-11',100);
insert into PRODUCT values ('P0002', N'Vi??n u???ng LiverWell Navi', 129000, N'Vi???t Nam', 20, N'M??t gan', N'TR?????NG TH???', N'V???i c??c th??nh ph???n th???o d?????c thi??n nhi??n l??nh t??nh gi??p thanh l???c c?? th???, gi???i ?????c, m??t gan, vi??n u???ng gi???i ?????c gan LiverWell h??? tr??? ??i???u tr??? c??c b???nh vi??m gan v?? t??ng c?????ng ch???c n??ng gan, mang ?????n cho b???n m???t l?? gan kh???e m???nh.','2023-12-25',100);
insert into PRODUCT values ('P0003',N'G??i c???m Plus Kingphar', 25000, N'Vi???t Nam', 6, N'M??t gan', N'HERBITECH', N'Thanh Nhi???t Plus l?? s???n ph???m c???a C??ng ty C??? ph???n Kingphar Vi???t Nam. ????y l?? m???t trong nh???ng c??ng ty ti??n phong t???i Vi???t Nam trong l??nh v???c ch??m s??c s???c kh???e c???ng ?????ng b???ng c??c s???n ph???m c?? ngu???n g???c d?????c li???u t??? nhi??n ch???n l???c. B??n c???nh n???n t???ng kinh nghi???m c??y thu???c t??? d??n gian', '2024-12-23',100);
insert into PRODUCT values ('P0004',N'Vi??n u???ng Active Legs New Nordic', 320000, N'Th???y ??i???n', 30, N'Tim m???ch', N'LEGOSAN AB', N'Active Legs gi??p t??ng c?????ng l??u th??ng tu???n ho??n m??u, t??ng s???c b???n t??nh m???ch, h???n ch??? h??nh th??nh huy???t kh???i, ph??ng ng???a v?? h??? tr??? ??i???u tr??? suy gi??n t??nh m???ch ch??n, gi???m c??c tri???u ch???ng ??au ch??n, n???ng ch??n, t?? ch??n, g??n xanh n???i ??? ch??n???', '2025-12-23',100);
insert into PRODUCT values ('P0005',N'Vi??n u???ng Omexxel Cardio Excelife', 380000, N'M???', 300, N'Tim m???ch', N'EXCELIFE', N'Omexxel Cardio Excelife h??? tr??? t??ng c?????ng kh??? n??ng ch???ng oxy h??a, gi??p h???n ch??? x?? v???a ?????ng m???ch, gi??p duy tr?? s???c kh???e tim m???ch.', '2024-2-11',100);
insert into PRODUCT values ('P0006',N'Y???n s??o Green Bird Babi Nutrinest', 164000, N'Vi???t Nam', 100, N'Dinh d?????ng', N'NUTRINEST', N'Y???n s??o cho tr??? em Green Bird Babi h????ng vani ???????c l??m t??? th??nh ph???n y???n s??o h???u c?? cao c???p chu???n Asean Organic, ???????ng h???u c?? kh??ng t???y t??? c??y m??a kh??ng nhi???m thu???c tr??? s??u v?? ph??n b??n c??ng h????ng vani t??? c??y hoa vani t??? nhi??n. S???n ph???m gi??p t??ng c?????ng ????? kh??ng v?? h??? mi???n d???ch c???a c??c b??, h??? tr??? h??? ti??u h??a, cho b?? ph??t tri???n to??n di???n.', '2023-12-23',20);
insert into PRODUCT values ('P0007',N'C???m ColosMaxQ10 Gold QD-Meliphar',158000, N'Vi???t Nam', 20, N'Dinh d?????ng', N'QD-MELIPHAR', N'ColosMax Q10 cung c???p vitamin, kho??ng ch???t v?? c??c enzym ti??u ho??. H??? tr??? ti??u h??a v?? h???p thu th???c ??n, t??ng c?????ng s???c ????? kh??ng.', '2023-08-01',50);
insert into PRODUCT values ('P0008',N'Vi??n u???ng Collagen C Nature Bounty', 490000, N'??c', 100, N'L??m ?????p', N'COLLAGENE', N'Vi??n u???ng Collagen C Nature Bounty b??? sung collagen, vitamin C cho da (90 vi??n)', '2023-06-02',10);
insert into PRODUCT values ('P0009',N'Vi??n nhau thai c???u Placenta', 999000, N'NewZealand', 30, N'L??m ?????p', N'NZHEALTH', N'Placenta 25000 l?? s???n ph???m l??m ?????p c?? c??ng th???c ?????c ????o ???????c b??o ch??? t??? chi???t xu???t nhau thai c???u v?? chi???t xu???t h???t nho. S???n ph???m c?? xu???t x??? t??? ch??u ??u n??y h???a h???n s??? ??em l???i m???t l??n da tr??? ?????p, kh???e m???nh, g??p ph???n ho??n l???i tu???i thanh xu??n cho m???i ch??? em ph??? n???.', '2024-12-23',50);
insert into PRODUCT values ('P0010',N'Vi??n s???i Immune++ T???t Th??nh', 39000, N'Vi???t Nam', 30, N'Vitamin', N'PH??C L??M', N' Vi??n s???i kh??ng ???????ng Immune++ b??? sung beta glucan, k???m, c??c vitamin v?? kho??ng ch???t thi???t y???u gi??p t??ng c?????ng s???c kh???e, n??ng cao s???c ????? kh??ng cho c?? th???, gi??p t??ng c?????ng ti??u h??a ??n ngon mi???ng.', '2025-02-23',500);
select * from PRODUCT;

/*==============================================================*/
/* Table: DELIVERY                                              */
/*==============================================================*/

delete from DELIVERY;
insert into DELIVERY values('D0000', N'Mi???n ph?? ship', 0);
insert into DELIVERY values('D0001', N'Grab n???i th??nh', 20000);
insert into DELIVERY values('D0002', N'Grab ngo???i th??nh', 30000);
insert into DELIVERY values('D0003', N'Giao h??ng ti???t ki???m n???i th??nh', 10000);
insert into DELIVERY values('D0004', N'Giao h??ng ti???t ki???m ngo???i th??nh', 20000);

select * from DELIVERY;

/*==============================================================*/
/* Table: ACCOUNTANT                                            */
/*==============================================================*/

insert into ACCOUNTANT values('AC001',N'Nguy???n Ng???c ??n', '0128593320', N's??? 7, ???????ng 3 th??ng 2, qu???n 1, th??nh ph??? H??? Ch?? Minh' );
insert into ACCOUNTANT values('AC002',N'??o??n Ch??nh H???u', '0255202220', N's??? 12, ???????ng An S????ng, qu???n 4, th??nh ph??? H??? Ch?? Minh' );
insert into ACCOUNTANT values('AC003',N'Ph???m Sinh Danh Ho??ng', '0932456310', N'8/92/21, ???????ng H???u Th???, qu???n 3, th??nh ph??? H??? Ch?? Minh' );

select * from ACCOUNTANT;

/*==============================================================*/
/* Table: IMPORT	                                            */
/*==============================================================*/

ALTER TABLE IMPORT 
DROP COLUMN IMPORTDATE;


ALTER TABLE IMPORT 
ADD IMPORTDATE DATETIME;

delete  from IMPORT;
insert into IMPORT values ('I0001','AC001', '2022-11-11 10:10:20');
insert into IMPORT values ('I0002','AC001','2022-11-11 11:23:59');
insert into IMPORT values ('I0003','AC003','2022-11-12 10:05:20');
insert into IMPORT values ('I0004','AC002','2022-11-13 08:12:59');
insert into IMPORT values ('I0005','AC002','2022-11-14 13:05:12');

select * from IMPORT;

/*==============================================================*/
/* Table: IMPORT_DETAIL                                         */
/*==============================================================*/

delete from IMPORT_DETAIL;

insert into IMPORT_DETAIL values ('ID001','P0001','I0001',10);
insert into IMPORT_DETAIL values ('ID002','P0002','I0001',5);
insert into IMPORT_DETAIL values ('ID003','P0003','I0001',10);
insert into IMPORT_DETAIL values ('ID004','P0001','I0001',10);
insert into IMPORT_DETAIL values ('ID005','P0001','I0002',8);
insert into IMPORT_DETAIL values ('ID006','P0004','I0003',10);
insert into IMPORT_DETAIL values ('ID007','P0003','I0003',20);
insert into IMPORT_DETAIL values ('ID008','P0010','I0004',5);
insert into IMPORT_DETAIL values ('ID009','P0007','I0004',10);
insert into IMPORT_DETAIL values ('ID010','P0009','I0005',15);

select * from IMPORT_DETAIL;

/*==============================================================*/
/* Table: AGENTS		                                        */
/*==============================================================*/

delete from AGENT;

insert into AGENT values ('AG001', N'?????i l?? s??? 3', N'S??? 3, ???????ng T??n Phong, qu???n 7, TP.HCM', 'dailyso3@gmail.com','0900045566');
insert into AGENT values ('AG002', N'?????i l?? Ho??ng Di???t', N'S??? 45, ???????ng T??y H??a, qu???n 5, TP.HCM', 'hoangdiet@gmail.com','076222266');
insert into AGENT values ('AG003', N'Nh?? thu???c Long', N'S??? 23, ???????ng H???u Th???, qu???n 12, TP.HCM', 'longchau@medicine.com','0220052666');
insert into AGENT values ('AG004', N'S??? l??? TPCN Meo Meo', N'S??? 47, ???????ng T??n Phong, qu???n Th??? ?????c, TP.HCM', 'meohealthy@gmail.com','0978555201');

select * from AGENT;


/*==============================================================*/
/* Table: ORDER			                                        */
/*==============================================================*/

alter table "ORDER"
alter Column ORDERSTATUS NVARCHAR(20);
alter table "ORDER"
alter Column PAYMENTSTATUS NVARCHAR(20);
alter table "ORDER"
alter Column PAYMENTMETHOD NVARCHAR(30);

delete from "ORDER";

insert into "ORDER" values ('O0001', 'AG001','D0000','2022-11-15',N'???? nh???n ???????c h??ng',N'???? thanh to??n', N'Chuy???n kho???n');
insert into "ORDER" values ('O0002', 'AG002','D0001','2022-11-17',N'??ang giao h??ng',N'Ch??a thanh to??n', N'Thanh to??n khi nh???n h??ng');
insert into "ORDER" values ('O0003', 'AG001','D0003','2022-11-18',N'??ang chu???n b??? h??ng',N'???? thanh to??n', N'Chuy???n kho???n');

select * from "ORDER";

/*==============================================================*/
/* Table: ORDER_DETAIL	                                        */
/*==============================================================*/

insert into ORDER_DETAIL values ('OD001','O0001', 'P0001',15);
insert into ORDER_DETAIL values ('OD002','O0001', 'P0002',15);
insert into ORDER_DETAIL values ('OD003','O0001', 'P0006',20);
insert into ORDER_DETAIL values ('OD004','O0002', 'P0001',10);
insert into ORDER_DETAIL values ('OD005','O0003', 'P0004',10);
insert into ORDER_DETAIL values ('OD006','O0003', 'P0001',15);

select * from ORDER_DETAIL;

Select * from "ORDER"  where  ORDERSTATUS != N'??ang giao h??ng';




/*==============================================================*/
/* Part :      Edit table Product	                            */
/* Created on:     12/02/2022 7:39:49 PM						*/
/*==============================================================*/

/*==============================================================*/
/* Table: PRODUCT                                               */
/*==============================================================*/
alter table PRODUCT add PROIMAGE VARCHAR(50);

UPDATE PRODUCT SET PROIMAGE = 'P001_vien_sui_optimax.jpg' where PRODUCTID = 'P0001';
UPDATE PRODUCT SET PROIMAGE = 'P002_liverwell_navi.png' where PRODUCTID = 'P0002';
UPDATE PRODUCT SET PROIMAGE = 'P003_thanh_nhiet_plus_kingphar.jpg' where PRODUCTID = 'P0003';
UPDATE PRODUCT SET PROIMAGE = 'P004_active_legs.jpg' where PRODUCTID = 'P0004';
UPDATE PRODUCT SET PROIMAGE = 'P005_vien_uong_omexxel.jpg' where PRODUCTID = 'P0005';
UPDATE PRODUCT SET PROIMAGE = 'P006_yen_sao_green_bird.jpg' where PRODUCTID = 'P0006';
UPDATE PRODUCT SET PROIMAGE = 'P007_com_coloesmaxq10.jpg' where PRODUCTID = 'P0007';
UPDATE PRODUCT SET PROIMAGE = 'P008_colagen_beuty.jpg' where PRODUCTID = 'P0008';
UPDATE PRODUCT SET PROIMAGE = 'P009_vien_nhau_thai_cuu.png' where PRODUCTID = 'P0009';
UPDATE PRODUCT SET PROIMAGE = 'P010_sui_immune.jpg' where PRODUCTID = 'P0010';

SELECT * FROM PRODUCT;

select * from agent, "order" where agent.AGENTID = "order".AGENTID;

Select ORDERDATE from "ORDER" where ORDERID;

Select PRODUCTID as "M?? s???n ph???m", PRONAME as "T??n s???n ph???m", HASSOLD as "???? b??n" from PRODUCT order by  HASSOLD Desc; 