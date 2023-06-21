-- Roles
INSERT INTO public."AspNetRoles"("Id", "Name", "NormalizedName", "ConcurrencyStamp") VALUES ('3f9a196f-a174-4ed0-b7a2-4311d481aa6c', 'Admin', 'ADMIN', null);
INSERT INTO public."AspNetRoles"("Id", "Name", "NormalizedName", "ConcurrencyStamp") VALUES ('721c3418-122b-417d-a100-2d77f90e6265', 'Users', 'USERS', null);
INSERT INTO public."AspNetRoles"("Id", "Name", "NormalizedName", "ConcurrencyStamp") VALUES ('dbf308dd-c988-4a32-97c7-72558d96f7be', 'Company', 'COMPANY', null);

-- Countries
INSERT Into public."Countries" ("Id","CountryName","IsDefault","DisplayOrder","CountryStatusType","DateCreated","DateLastUpdate","Version")values ('01GZTM8DSTQH037TNTFSK9RX9W',N'ایران',true,1,1,'2023-05-29 08:18:40.724763 +00:00','2023-05-29 08:18:40.724763 +00:00',0);

-- Provinces
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01GZTMF256K84ZGQFMWRB6VTV9',N'فارس',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724805 +00:00','2023-05-29 08:18:40.724805 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01GZTT98N8S8TE5J1WE205Q4WV',N'تهران',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724793 +00:00','2023-05-29 08:18:40.724794 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EM0ETHJXSCSCVAA279',N'همدان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724821 +00:00','2023-05-29 08:18:40.724821 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EM2HNY8V6FMBJ8KNGJ',N'خراسان رضوي',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724797 +00:00','2023-05-29 08:18:40.724797 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EM3V9V0YQ24VWQH3NW',N'زنجان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724802 +00:00','2023-05-29 08:18:40.724802 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EM4B4CX6C4NNEM7758',N'گيلان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724815 +00:00','2023-05-29 08:18:40.724815 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EM4G2AZKW55G0XXY4K',N'چهارمحال بختياري',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724795 +00:00','2023-05-29 08:18:40.724795 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EM4VCR6P076HZP9NE0',N'سمنان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724803 +00:00','2023-05-29 08:18:40.724803 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EM5F4CA14SHBQY5A3M',N'ايلام',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724790 +00:00','2023-05-29 08:18:40.724790 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EM5RX3H602KTN8B645',N'قزوين',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724806 +00:00','2023-05-29 08:18:40.724807 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EM6F55N6Y6KGWFN9T6',N'قم',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724808 +00:00','2023-05-29 08:18:40.724808 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EM90RG4C1EEWTMV7T7',N'سيستان و بلوچستان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724804 +00:00','2023-05-29 08:18:40.724804 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMAQX3TWKE4E2QYF7D',N'يزد',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724822 +00:00','2023-05-29 08:18:40.724822 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMB12ERVXGDF2H1CTN',N'كرمان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724810 +00:00','2023-05-29 08:18:40.724810 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMB464J1AXYQD5M1S3',N'گلستان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724814 +00:00','2023-05-29 08:18:40.724814 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMFQEMR64YSEWW97KQ',N'كرمانشاه',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724811 +00:00','2023-05-29 08:18:40.724811 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMGDCWYDZEWS9JEM7S',N'اصفهان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724788 +00:00','2023-05-29 08:18:40.724788 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMJ26V58SN60PVHVKB',N'كردستان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724809 +00:00','2023-05-29 08:18:40.724809 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMKH817CEGRZM1C1CZ',N'اردبيل',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724787 +00:00','2023-05-29 08:18:40.724787 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMMCQ9RVJ3ND78RXGZ',N'مازندران',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724817 +00:00','2023-05-29 08:18:40.724817 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMN9WZRNTXJA9B2KCK',N'بوشهر',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724791 +00:00','2023-05-29 08:18:40.724791 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMNJDGMT1C8XZBKDFA',N'آذربايجان غربي',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724785 +00:00','2023-05-29 08:18:40.724785 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMPTXCDES80PH5VK17',N'كهكيلويه و بويراحمد',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724813 +00:00','2023-05-29 08:18:40.724813 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMT7FWNBAEJXNMMR5J',N'خراسان شمالي',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724798 +00:00','2023-05-29 08:18:40.724798 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMVCW72SFKRW8EX78W',N'خوزستان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724800 +00:00','2023-05-29 08:18:40.724800 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMVFQ9N0RPTG9ZM5FW',N'مركزي',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724819 +00:00','2023-05-29 08:18:40.724819 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMVN4RWA5CB93GNMBA',N'لرستان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724816 +00:00','2023-05-29 08:18:40.724816 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMWANWYD74B58CS011',N'البرز',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724792 +00:00','2023-05-29 08:18:40.724792 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMXJS0W9WM8J4NNWQH',N'خراسان جنوبي',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724796 +00:00','2023-05-29 08:18:40.724796 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1K9D1EMXWHRAJGAH13Q7S2A',N'هرمزگان',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00',0);
INSERT Into public."Provinces" ("Id", "ProvinceName", "IsDefault", "DisplayOrder", "ProvinceStatusType", "IdCountry", "DateCreated", "DateLastUpdate", "Version")values ('01H1RJ85TYEB5WQWQTEGTS95Q9',N'آذربايجان شرقی',true,1,1,'01GZTM8DSTQH037TNTFSK9RX9W','2023-05-29 08:18:40.724785 +00:00','2023-05-29 08:18:40.724785 +00:00',0);

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYWE995BNDK95DMJY9', N'آذر شهر',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYW7DB8MHHNRBZ7N14', N'اسكو',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYP123XB5TQJFXX60B', N'اهر',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYCX2SRTESVEZFX9RD', N'بستان آباد',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY9W8S8JDCJF5B94Y5', N'بناب',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYTN3R6AE1RM4SN81B', N'بندر شرفخانه',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYYX16Q2KZ6MRTHF9K', N'تبريز',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYDQNW7EVF4WV4ETKK', N'تسوج',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYDR1V82947923CFYK', N'جلفا',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYVQ1WPHVTPSKBZ9RD', N'سراب',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYK873Q3HPMDKYNSEN', N'شبستر',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYEANQQKGJ01TYKY56', N'عجبشير',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY094YCRPGV5CCWFNA', N'قره آغاج',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYDVGWBMK2ZX37XFHM', N'كليبر',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYKPTJ005MQDATQ8NH', N'كندوان',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY535CEBPJ99JW6YR3', N'مرند',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYW6QWX7GQCMWPTDEW', N'ملكان',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYPAAH8FNV9YHDBRXP', N'ميانه',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY1RK1W7NDA6Q9C4VJ', N'مراغه',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY2T0D7PWV2RNPEDW9', N'هاديشهر',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY9A4XRRYCH2SFCZTM', N'هشترود',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY3BSTA1RV8QTKWQNK', N'هريس',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY9YCX19GYBY5Y1R1V', N'ورزقان',true,0,'01H1RJ85TYEB5WQWQTEGTS95Q9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY6ZM4X6VSFEY7EPSH', N'اروميه',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYA3K3F77J0X7X59YB', N'اشنويه',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYYKCPBD0KMHZ1RDSS', N'بوكان',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY4SH1WSJMCKRCNF6P', N'تكاب',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYN9D2VE9A97JYM4E6', N'پيرانشهر',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYQ8A9W02AS62NECCF', N'پلدشت',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYRTCQPJGA2PG5GZXA', N'چالدران',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY81GE0AZCA3VW4HAS', N'خوي',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY1PKHTFD7BYS5RSRQ', N'سر دشت',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY8JQM569PC94QPQZ9', N'سلماس',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYBT2MPA4QHGKYW196', N'شاهين دژ',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY9P69GYE58NGSN22M', N'شوط',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY884HCZV756ADE4KP', N'چايپاره',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYDJCBQ0PH04R2TY6W', N'ماكو',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYAHBTMPHEDA4HGA7F', N'مهاباد',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY5P7E2S84DH03H1FQ', N'مياندوآب',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY5E7ECY5C7MJ8V4XM', N'نقده',true,0,'01H1K9D1EMNJDGMT1C8XZBKDFA',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY4CDYD1V9TJ3XJ13P', N'اردبيل',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY42VF7RYKGJXTYNW8', N'بيله سوار',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYFT5Y9Z4C5XGHCBAB', N'پارس آباد',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYMDVZ0Y6N8WQXXBHS', N'خلخال',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYE2TBDZGZB99YSE5N', N'سرعين',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYWHAVENR7NDZHK8CM', N'كوثر',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYE7D00205R80MFSQ3', N'كيوي',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYGH402A751M4JP93P', N'گرمي',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY2P8DGYFSVN4ZFTK5', N'مشگين شهر',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY28VMV6C2MCWVCAQW', N'مغان',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYT9C4N6376ARCNEBB', N'نمين',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYJHM0AVFZMNP010SM', N'نير',true,0,'01H1K9D1EMKH817CEGRZM1C1CZ',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYG1B8QG0A78PSM7T4', N'آران و بيدگل',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY94R47RG3QW5BR7DG', N'اردستان',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYMAXDFCV1GC6Y927G', N'اصفهان',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYFE22E2511TVKD7F4', N'باغ بهادران',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY584P86ZFE59SZ9C3', N'تيران',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY62CF0DQWWWT7MYZG', N'خميني شهر',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYAYYNSK5JF9VCHVRX', N'خوانسار',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY5M424ZGKBGK2TVYN', N'زرين شهر',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY2PWRRQGK5PNZVAG6', N'سميرم',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYG130780BYYFNGJND', N'شاهين شهر',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYAF6A29TWET3APV1S', N'شهرضا',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYVB808E1G6BSF471G', N'فريدن',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY34P0KDXE4DBBT9R3', N'فريدون شهر',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY214Z15030EGGWR68', N'فلاورجان',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY0T447VD7YP9QSNZN', N'فولاد شهر',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYCNJCXBM9XS34PW1D', N'كاشان',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYNBKF63R3Z467ZCRT', N'گلپايگان',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY12T51GDC58831Y6N', N'مباركه',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYCG7VM1TP2K20SYEK', N'نايين',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYAXRFNRPCJZHYTKCV', N'نجف آباد',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY6N0NGJBPXMEV0CQF', N'نطنز',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYBKCAF43X1VKKXP4R', N'دهاقان',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY5B6CCNQG1P6HQETY', N'سپاهان شهر',true,0,'01H1K9D1EMGDCWYDZEWS9JEM7S',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM00RXHVSABN10HC3A', N'قایِمییه',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM5J8TYD4NSKDWDPZX', N'صدرا',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMKSJ8PN61SKJKCVR8', N'کوار',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMGCJB3WMP12GB8MEA', N'اوز',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMWHEV7QWVV5DXZSCZ', N'جویم',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM60Y24N1RWGRS6FQK', N'بنارویه',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM0162CA5Z9F1QZZTC', N'بلغان',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMQCQ0527XDBQWK2CZ', N'کاریان',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMRTAQT2H9HGP6GYFV', N'بیدشهر',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMWXHEZYBZBHXA7YNG', N'کوره',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMX37QAM8XNXPB4F9B', N'گراش',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM7CXPHF3C1JAZRWJT', N'آباده',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYWF1QMC06GEWHFHB8', N'اردكان',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYFG1E5CY6T8S3SAHF', N'ارسنجان',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY8E6NBV0YVJNE0ECY', N'استهبان',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYPSSA5XF0P8MJX0Y6', N'اقليد',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYP1MPG5HCVZ9R369C', N'جهرم',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYZ6RXY81GGWHPBRAM', N'حاجي آباد',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYF3FMJ0SWXT2GFB84', N'خرم بيد',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYVHR56JW4VE32E1QP', N'داراب',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY48S36Y895PF0XYA2', N'سپيدان',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY8CXCX99JTA5MBP8E', N'سروستان',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYXZS2VYR0JZMYCDT7', N'سوريان',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY3F9K9M81S652S5M9', N'شيراز',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYJ6ZJMZQYK9KXWF0J', N'صفاشهر',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYKY5KVZT29ERV3916', N'فراشبند',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY1NZQ3GJNSK9P3HGQ', N'فسا',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYHJG7YBBR30N33B5J', N'فيروز آباد',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYPTJRKTFAQT6HHYM7', N'قيروكارزين',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TY3ZHEJT25B50KENGZ', N'كازرون',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TYWZJ2RA1VKERWB45Z', N'لار',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431QS1SC22K0JD7EXKQS0', N'لامرد',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3HX38YWQWV8SQC8E5', N'مرودشت',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3JNBNQ0VWMTKJD9WD', N'ممسني',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R39GRCERK46MXHX1AK', N'مهر',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3RYNY6A8DV5GDC69G', N'ني ريز',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3HWA2C3BXXD1Q31JA', N'نورآباد',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3X5HJ59YK18MVXNYM', N'خنج',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R376VERQSWKH535JGM', N'پاسارگاد',true,0,'01GZTMF256K84ZGQFMWRB6VTV9',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMERHKMZ0HEFXMJF49', N'آبدانان',true,0,'01H1K9D1EM5F4CA14SHBQY5A3M',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMHAV76DTGH7QQ7G4Y', N'ايلام',true,0,'01H1K9D1EM5F4CA14SHBQY5A3M',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM6GNPR5Q2C0TQ395X', N'ايوان',true,0,'01H1K9D1EM5F4CA14SHBQY5A3M',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMZKA2JVSTNXVW2S5T', N'دره شهر',true,0,'01H1K9D1EM5F4CA14SHBQY5A3M',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMAKYQYRJYFRVGGA58', N'دهلران',true,0,'01H1K9D1EM5F4CA14SHBQY5A3M',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMA7NB16S9JCMQTCM5', N'سرابله',true,0,'01H1K9D1EM5F4CA14SHBQY5A3M',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMJ6RTTSNXYDYSYYRX', N'شيروان چرداول',true,0,'01H1K9D1EM5F4CA14SHBQY5A3M',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM6PVJ737JJ8XXVC6J', N'مهران',true,0,'01H1K9D1EM5F4CA14SHBQY5A3M',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMXN3KB04VQZW40VY7', N'اهرم',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMF2VZTNTH0K56MQRB', N'بوشهر',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM57ACK0TS5EJNZYFR', N'تنگستان',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMFANQ24FQ9TVVW04E', N'خارك',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM4MBAFWZ9T5GRAF42', N'خورموج',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM6YMEXP26J715JXW4', N'دير',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMQ6X4N48SV092K43X', N'دشتستان',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMT1E4MFMEKFGG5GJT', N'دشتي',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMRX9HYERWHPE15ZEM', N'ديلم',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM8MTCW6XD1Z6NBKXT', N'ريشهر',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMP1PAM2EQ9K4RV9TR', N'كنگان',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM8HTJZAG2Z44V0N5S', N'گناوه',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SME6BACFGVW0EAQN4H', N'عسلويه',true,0,'01H1K9D1EMN9WZRNTXJA9B2KCK',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMJ2QJ6DBMSFFFV755', N'كرج',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMY49R817W2PWJJSM0', N'آسارا',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMMYWS50FC1X22X7H6', N'اشتهارد',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMPTF59JQ7WKY0C0NQ', N'هشتگرد',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM4HGXV3W3B5NF4ESV', N'كوهسار',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMDN1HERBPWFH9ADFE', N'چهارباغ',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMWB4ZWZVW63P8YMXP', N'طالقان',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM7TGJ2D3Z1YCNCEVJ', N'جوستان',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM6DB99H16GYGZR45W', N'نظرآباد',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMTEP33JAS26K3TBNE', N'تنكمان',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM367SH4B9HPGV2M0F', N'ساوجبلاغ',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SM6T6VTTXHVMTHNB0A', N'فرديس',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431SMCWVJAJG8VH8YWAGV', N'مهرشهر',true,0,'01H1K9D1EMWANWYD74B58CS011',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3TYK335GGHNSCTTVC', N'اسلامشهر',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3R8MEC442KR67JE8H', N'بومهن',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3G6CJVJ48A5JE0CMC', N'تجريش',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3GSY1JF2CVZCQ1341', N'تهران',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3BAQNQ5J5SMPEVPG1', N'پاكدشت',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3HASK2KYPYY5NGT1Q', N'دماوند',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3YWVD2QS6TNCE2F0A', N'رباط كريم',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3TV2W231KHXC4FS06', N'ري',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R355JX3SZ62JZMT5ZC', N'رودهن',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3DNQG3MC1NRYN6H60', N'شريف آباد',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3SGBK9A7E9RSBMQC4', N'شهريار',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R34NJ1XAHG4EN9AEVR', N'فشم',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3G5W9TFNQKQQ66QPW', N'فيروزكوه',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3R9WGW623BP78SRR3', N'قدس',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3MQ0ESAWXMJRJA3M9', N'قرچك',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3GGXBGSJ7XK1FWEHY', N'كن',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3T904D9HC5CH33SYR', N'كهريزك',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R383XAT89GFRY1G14Q', N'گلستان',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R39Q1BY88R10CVPJVA', N'لواسان',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R37R2Z719Y61KEK6W3', N'ملارد',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3KFZR5E973WQW5242', N'ورامين',true,0,'01GZTT98N8S8TE5J1WE205Q4WV',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R372G6CFCPNS9V6NM4', N'اردل',true,0,'01H1K9D1EM4G2AZKW55G0XXY4K',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R34550RDFJPZB945R3', N'بروجن',true,0,'01H1K9D1EM4G2AZKW55G0XXY4K',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3AQ3Y7EVVPQ10DCY5', N'چلگرد',true,0,'01H1K9D1EM4G2AZKW55G0XXY4K',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R38RCHPVB4P6E2M003', N'سامان',true,0,'01H1K9D1EM4G2AZKW55G0XXY4K',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3XD4VBHWKDEP48DS9', N'شهركرد',true,0,'01H1K9D1EM4G2AZKW55G0XXY4K',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R37CJPF8FCHN7J12PM', N'فارسان',true,0,'01H1K9D1EM4G2AZKW55G0XXY4K',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1S431R3XV636J3RTM9D92VR', N'لردگان',true,0,'01H1K9D1EM4G2AZKW55G0XXY4K',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');





24
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'بيرجند',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'بشرویه',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'خضری',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'سربيشه',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'قائن',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'نهبندان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'فردوس',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'سرايان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'طبس',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

25
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'بردسكن',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'تايباد',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'تربت جام',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'تربت حيدريه',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'چناران',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'خواف',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'درگز',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'سبزوار',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'سرخس',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'طرقبه',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'فريمان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'قوچان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'كاخك',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'كلات',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'كاشمر',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'گناباد',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'مشهد',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'نيشابور',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'رشتخوار',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'جوين',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'خليل آباد',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

26
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'آشخانه',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسفراين',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'بجنورد',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'جاجرم',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'شيروان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

27
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'آبادان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اميديه',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'انديمشك',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اهواز',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'ايرانشهر',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'ايذه',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'باغ ملك',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'بندرامام خميني',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'بندر ماهشهر',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'بهبهان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'دزفول',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'خرمشهر',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'رامهرمز',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'سوسنگرد',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'شادگان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'شوش',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'شوشتر',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'لالي',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'مسجد سليمان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'هنديجان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'هويزه',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

28
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'ابهر',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'ايجرود',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'خرمدره',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'زنجان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'قيدار',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'طارم',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'ماهنشان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

29
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'ايوانكي',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'بسطام',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'سمنان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'شاهرود',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")

30
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'دامغان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'گرمسار',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'ايرانشهر',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'چابهار',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'خاش',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'راسك',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'زابل',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'زاهدان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'سراوان',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'سرباز',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'ميرجاوه',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'نيكشهر',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');


32
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (341, 32, N'آبيك
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (342, 32, N'بوئين زهرا
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (343, 32, N'تاكستان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (344, 32, N'قزوين
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (345, 32, N'الوند
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

33
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (346, 33, N'قم
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (347, 33, N'جعفريه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

34
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (348, 34, N'بانه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (349, 34, N'بيجار
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (350, 34, N'ديواندره
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (351, 34, N'سقز
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (352, 34, N'سنندج
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (353, 34, N'قروه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (354, 34, N'كامياران
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (355, 34, N'مريوان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

35
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (356, 35, N'بابك
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (357, 35, N'بافت
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (358, 35, N'بردسير
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (359, 35, N'بم
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (360, 35, N'جيرفت
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (361, 35, N'راور
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (362, 35, N'رفسنجان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (363, 35, N'زرند
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (364, 35, N'سيرجان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (365, 35, N'كهنوج
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (366, 35, N'كرمان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (367, 36, N'اسلام آباد غرب
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (368, 36, N'پاوه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (369, 36, N'جوانرود
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (370, 36, N'سر پل ذهاب
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (371, 36, N'سنقر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (372, 36, N'صحنه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (373, 36, N'قصر شيرين
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (374, 36, N'كرمانشاه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (375, 36, N'كنگاور
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (376, 36, N'گيلان غرب
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (377, 36, N'هرسين
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (378, 37, N'دنا
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (379, 37, N'دوگنبدان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (380, 37, N'دهدشت
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (381, 37, N'سي سخت
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (382, 37, N'گچساران
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (383, 37, N'ياسوج
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (384, 38, N'آزاد شهر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (385, 38, N'آق قلا
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (386, 38, N'بندر گز
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (387, 38, N'تركمن
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (388, 38, N'راميان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (389, 38, N'علي آباد كتول
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (390, 38, N'كلاله
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (391, 38, N'كردكوي
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (392, 38, N'گنبد كاووس
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (393, 38, N'گرگان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (394, 38, N'مينو دشت
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (395, 39, N'آستانه اشرفيه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (396, 39, N'آستارا
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (397, 39, N'املش
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (398, 39, N'بندرانزلي
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (399, 39, N'تالش
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (400, 39, N'رشت
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (401, 39, N'رضوان شهر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (402, 39, N'رودبار
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (403, 39, N'رستم آباد
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (404, 39, N'رود سر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (405, 39, N'سياهكل
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (406, 39, N'شفت
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (407, 39, N'صومعه سرا
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (408, 39, N'فومن
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (409, 39, N'كلاچاي
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (410, 39, N'لاهيجان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (411, 39, N'لنگرود
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (412, 39, N'ماسال
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (413, 39, N'ماسوله
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (414, 39, N'منجيل
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (415, 39, N'هشتپر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (416, 40, N'ازنا
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (417, 40, N'الشتر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (418, 40, N'اليگودرز
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (419, 40, N'بروجرد
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (420, 40, N'پلدختر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (421, 40, N'خرم آباد
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (422, 40, N'دزفول
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (423, 40, N'دورود
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (424, 40, N'كوهدشت
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (425, 40, N'ماهشهر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (426, 40, N'نور آباد
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (427, 40, N'شول آباد
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (428, 41, N'آمل
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (429, 41, N'بابل
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (430, 41, N'بابلسر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (431, 41, N'بلده
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (432, 41, N'بهشهر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (433, 41, N'پل سفيد
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (434, 41, N'تنكابن
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (435, 41, N'ساري
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (436, 41, N'سواد كوه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (437, 41, N'جويبار
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (438, 41, N'چالوس
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (439, 41, N'رامسر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (440, 41, N'فريدون كنار
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (441, 41, N'قائم شهر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (442, 41, N'محمود آباد
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (443, 41, N'نكا
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (444, 41, N'نور
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (445, 41, N'نوشهر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (446, 41, N'گلوگاه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (447, 42, N'آشتيان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (448, 42, N'اراك
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (449, 42, N'تفرش
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (450, 42, N'خمين
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (451, 42, N'دليجان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (452, 42, N'ساوه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (453, 42, N'سربند
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (454, 42, N'سربند
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (455, 42, N'شازند
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (456, 42, N'محلات
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (457, 42, N'زرنديه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (458, 43, N'ابوموسي
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (459, 43, N'انگهران
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (460, 43, N'بستك
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (461, 43, N'بندر جاسك
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (462, 43, N'بندرعباس
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (463, 43, N'بندر لنگه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (464, 43, N'تنب بزرگ
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (465, 43, N'حاجي آباد
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (466, 43, N'دهبارز
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (467, 43, N'قشم
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (468, 43, N'كيش
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (469, 43, N'ميناب
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (470, 43, N'بندر خمير
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (471, 44, N'اسدآباد
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (472, 44, N'بهار
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (473, 44, N'تويسركان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (474, 44, N'رزن
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (475, 44, N'كبودر آهنگ
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (476, 44, N'ملاير
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (477, 44, N'نهاوند
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (478, 44, N'همدان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (479, 45, N'ابركوه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (480, 45, N'اردكان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (481, 45, N'اشكذر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (482, 45, N'بافق
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (483, 45, N'تفت
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (484, 45, N'مهريز
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (485, 45, N'ميبد
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (486, 45, N'هرات
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (487, 45, N'يزد
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (489, 43, N'بندر سیرک
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');



INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (491, 20, N'جم
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (492, 20, N'
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (493, 20, N'
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (494, 35, N'سرچشمه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (495, 22, N'پرند
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (496, 41, N'کلاردشت
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (499, 41, N'شیرگاه
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (500, 18, N'خور و بیابانک
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (501, 43, N'پارسیان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (503, 36, N'روانسر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (504, 30, N'کنارک
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');

INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (514, 27, N'گتوند
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (515, 27, N'رامشیر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (516, 19, N'بدره
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (517, 25, N'مه ولات
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (518, 34, N'دهگلان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (519, 29, N'میامی
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (520, 18, N'لنجان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (521, 18, N'سده
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (522, 35, N'منوجان
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (523, 41, N'کیا کلا
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');
INSERT into public."Cities" ("Id", "CityName", "IsDefault", "DisplayOrder", "IdProvince", "CityStatusType", "DateCreated", "DateLastUpdate")
VALUES (524, 22, N'نسیم شهر
VALUES ('01H1RJ85TN1RRNAHJZE84VJ4JH', N'اسكو',true,0,'01GZTM8DSTQH037TNTFSK9RX9W',1,'2023-05-29 08:18:40.724820 +00:00','2023-05-29 08:18:40.724820 +00:00');



