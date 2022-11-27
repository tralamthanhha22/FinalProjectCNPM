
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
insert into PRODUCT values ('P0006',N'Yến sào Green Bird Babi Nutrinest', 164000, N'Việt Nam', 100, N'Dinh dưỡng', N'NUTRINEST', N'Yến sào cho trẻ em Green Bird Babi hương vani được làm từ thành phần yến sào hữu cơ cao cấp chuẩn Asean Organic, đường hữu cơ không tẩy từ cây mía không nhiễm thuốc trừ sâu và phân bón cùng hương vani từ cây hoa vani tự nhiên. Sản phẩm giúp tăng cường đề kháng và hệ miễn dịch của các bé, hỗ trợ hệ tiêu hóa, cho bé phát triển toàn diện.', '2023-12-23',20);
insert into PRODUCT values ('P0007',N'Cốm ColosMaxQ10 Gold QD-Meliphar',158000, N'Việt Nam', 20, N'Dinh dưỡng', N'QD-MELIPHAR', N'ColosMax Q10 cung cấp vitamin, khoáng chất và các enzym tiêu hoá. Hỗ trợ tiêu hóa và hấp thu thức ăn, tăng cường sức đề kháng.', '2023-08-01',50);
insert into PRODUCT values ('P0008',N'Viên uống Collagen C Nature Bounty', 490000, N'Úc', 100, N'Làm đẹp', N'COLLAGENE', N'Viên uống Collagen C Nature Bounty bổ sung collagen, vitamin C cho da (90 viên)', '2023-06-02',10);
insert into PRODUCT values ('P0009',N'Viên nhau thai cừu Placenta', 999000, N'NewZealand', 30, N'Làm đẹp', N'NZHEALTH', N'Placenta 25000 là sản phẩm làm đẹp có công thức độc đáo được bào chế từ chiết xuất nhau thai cừu và chiết xuất hạt nho. Sản phẩm có xuất xứ từ châu Âu này hứa hẹn sẽ đem lại một làn da trẻ đẹp, khỏe mạnh, góp phần hoàn lại tuổi thanh xuân cho mọi chị em phụ nữ.', '2024-12-23',50);
insert into PRODUCT values ('P0010',N'Viên sủi Immune++ Tất Thành', 39000, N'Việt Nam', 30, N'Vitamin', N'PHÚC LÂM', N' Viên sủi không đường Immune++ bổ sung beta glucan, kẽm, các vitamin và khoáng chất thiết yếu giúp tăng cường sức khỏe, nâng cao sức đề kháng cho cơ thể, giúp tăng cường tiêu hóa ăn ngon miệng.', '2025-02-23',500);
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

/*==============================================================*/
/* Table: ACCOUNTANT                                            */
/*==============================================================*/

insert into ACCOUNTANT values('AC001',N'Nguyễn Ngọc Ân', '0128593320', N'số 7, đường 3 tháng 2, quận 1, thành phố Hồ Chí Minh' );
insert into ACCOUNTANT values('AC002',N'Đoàn Chính Hữu', '0255202220', N'số 12, đường An Sương, quận 4, thành phố Hồ Chí Minh' );
insert into ACCOUNTANT values('AC003',N'Phạm Sinh Danh Hoàng', '0932456310', N'8/92/21, đường Hữu Thọ, quận 3, thành phố Hồ Chí Minh' );

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

insert into AGENT values ('AG001', N'Đại lý số 3', N'Số 3, đường Tân Phong, quận 7, TP.HCM', 'dailyso3@gmail.com','0900045566');
insert into AGENT values ('AG002', N'Đại lý Hoàng Diệt', N'Số 45, đường Tây Hòa, quận 5, TP.HCM', 'hoangdiet@gmail.com','076222266');
insert into AGENT values ('AG003', N'Nhà thuốc Long', N'Số 23, đường Hữu Thọ, quận 12, TP.HCM', 'longchau@medicine.com','0220052666');
insert into AGENT values ('AG004', N'Sỉ lẻ TPCN Meo Meo', N'Số 47, đường Tân Phong, quận Thủ Đức, TP.HCM', 'meohealthy@gmail.com','0978555201');

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

insert into "ORDER" values ('O0001', 'AG001','D0000','2022-11-15',N'Đã nhận được hàng',N'Đã thanh toán', N'Chuyển khoản');
insert into "ORDER" values ('O0002', 'AG002','D0001','2022-11-17',N'Đang giao hàng',N'Chưa thanh toán', N'Thanh toán khi nhận hàng');
insert into "ORDER" values ('O0003', 'AG001','D0003','2022-11-18',N'Đang chuẩn bị hàng',N'Đã thanh toán', N'Chuyển khoản');

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





