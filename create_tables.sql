drop table product;

CREATE TABLE [product] (
  [productID] INTEGER NOT NULL PRIMARY KEY
, [name] TEXT NOT NULL DEFAULT ''
, [description] TEXT NOT NULL DEFAULT ''
, [price] double(10, 2) NOT NULL
, [active] bit NOT NULL DEFAULT 1
, [hasSN] bit NOT NULL DEFAULT 1
);

drop table specialPrices;

CREATE TABLE [specialPrices] (
  [customerID] INTEGER NOT NULL
, [productID] INTEGER NOT NULL
, [price] double(10, 2) NOT NULL
, FOREIGN KEY(customerID) references customers(customerID) 
, FOREIGN KEY(productID) references product(productID)
, PRIMARY KEY(customerID, productID)
);

drop table customers;

CREATE TABLE [customers] (
  [customerID] INTEGER NOT NULL PRIMARY KEY
, [contactName] TEXT NOT NULL DEFAULT ''
, [coName] TEXT NOT NULL DEFAULT ''
, [payTerms] TEXT NOT NULL DEFAULT ''
, [addressSame] bit NOT NULL DEFAULT 1
, [active] bit NOT NULL DEFAULT 1
, [specialPricing] bit NOT NULL DEFAULT 0
);

--INSERT INTO customers(customerID, coName, contactName, payTerms, addressSame, specialPricing) VALUES(9121, "Mach Motion", "hhhhh", "Net-30", 0, 1);
--INSERT INTO customers(customerID, coName, contactName, payTerms, addressSame, specialPricing) VALUES(1250, "Hilmot LLC", "xxxxxx", "Net-45", 1, 1);

drop table billAddress;

CREATE TABLE [billAddress] (
  [customerID] INTEGER NOT NULL PRIMARY KEY
, [billCoName] TEXT NOT NULL DEFAULT ''
, [billAddr1] TEXT DEFAULT ''
, [billAddr2] TEXT DEFAULT ''
, [billCity] TEXT DEFAULT ''
, [billState] TEXT DEFAULT ''
, [billZip] TEXT DEFAULT ''
, [billCountry] TEXT DEFAULT ''
, [billPhoneNo] TEXT DEFAULT ''
, FOREIGN KEY(customerID) references customers(customerID) 
);

--INSERT INTO billAddress(customerID, billCoName, billAddr1, billCity, billState, billZip, billCountry, billPhoneNo) VALUES(9121, "a;lksjdl;kjf", "ijdidijdi", "asdfasdf", "zzO", "333333", "US", "3333333333");

drop table shipAddress;

CREATE TABLE [shipAddress] (
  [customerID] INTEGER NOT NULL PRIMARY KEY
, [shipCoName] TEXT NOT NULL DEFAULT ''
, [shipAddr1] TEXT DEFAULT ''
, [shipAddr2] TEXT DEFAULT ''
, [shipCity] TEXT DEFAULT ''
, [shipState] TEXT DEFAULT ''
, [shipZip] TEXT DEFAULT ''
, [shipCountry] TEXT DEFAULT ''
, [shipPhoneNo] TEXT DEFAULT ''
, FOREIGN KEY(customerID) references customers(customerID) 
);

--INSERT INTO shipAddress(customerID, billCoName, billAddr1, billCity, billState, billZip, billCountry, billPhoneNo) VALUES(9121, "a;lksjdl;kjf", "ijdidijdi", "asdfasdf", "zzO", "333333", "US", "573-341-1528");

drop table manifest;

CREATE TABLE [manifest] (
  [orderID] INTEGER NOT NULL
, [productID] INTEGER NOT NULL
, [qty] INTEGER NOT NULL
, FOREIGN KEY(orderID) references orderHistory(orderID)
, FOREIGN KEY(productID) references product(productID)
, PRIMARY KEY(customerID, productID)
);

--INSERT INTO manifest(orderID, productID, qty) VALUES(11195, 8, 4);

drop table orderHistory;

CREATE TABLE [orderHistory] (
  [orderID] INTEGER NOT NULL PRIMARY KEY
, [customerID] INTEGER NOT NULL
, [poNum] TEXT NOT NULL
, [trackNum] TEXT NOT NULL DEFAULT ''
, [shipType] TEXT NOT NULL DEFAULT ''
, [shipDate] DATE NOT NULL DEFAULT CURRENT_DATE
, FOREIGN KEY(customerID) references customers(customerID)
);

--INSERT INTO orderHistory(orderID, poNum, trackNum, shipType, shipDate, customerID) VALUES(11195, '5335', 'sdasffwfwfwfff', 'UPS GND', '2017-04-11', 9121);

drop table serialNumbers;

CREATE TABLE [serialNumbers] (
  [ID] INTEGER NOT NULL PRIMARY KEY
, [productID] INTEGER NOT NULL
, [orderID] INTEGER NOT NULL
, [serialNum] TEXT NOT NULL  
, [closedLoop] bit NOT NULL DEFAULT 0
, [extIO] bit NOT NULL DEFAULT 0
, [analogInputs] bit NOT NULL DEFAULT 0
, [rigidTap] bit NOT NULL DEFAULT 0
, [thc] bit NOT NULL DEFAULT 0
, [macroProg] bit NOT NULL DEFAULT 0
, [threading] bit NOT NULL DEFAULT 0
, FOREIGN KEY(orderID) references orderHistory(orderID)
, FOREIGN KEY(productID) references product(productID)
);

--INSERT INTO serialNumbers(productID, orderID, serialNum, closedLoop, extIO, analogInputs, rigidTap, thc, macroProg, threading) VALUES(9, 9211, '123412341234', 1, 0, 0, 0, 0, 0, 0)
