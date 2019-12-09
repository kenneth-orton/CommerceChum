drop table if exists product;

CREATE TABLE [product] (
  [productID] INTEGER NOT NULL PRIMARY KEY
, [name] TEXT NOT NULL DEFAULT ''
, [description] TEXT NOT NULL DEFAULT ''
, [price] double(10, 2) NOT NULL
, [active] bit NOT NULL DEFAULT 1
, [hasSN] bit NOT NULL DEFAULT 1
);

drop table if exists customers;

CREATE TABLE [customers] (
  [customerID] INTEGER NOT NULL PRIMARY KEY
, [contactName] TEXT NOT NULL DEFAULT ''
, [coName] TEXT NOT NULL DEFAULT ''
, [payTerms] TEXT NOT NULL DEFAULT ''
, [addressSame] bit NOT NULL DEFAULT 1
, [active] bit NOT NULL DEFAULT 1
, [specialPricing] bit NOT NULL DEFAULT 0
);

drop table if exists specialPrices;

CREATE TABLE [specialPrices] (
  [customerID] INTEGER NOT NULL
, [productID] INTEGER NOT NULL
, [price] double(10, 2) NOT NULL
, FOREIGN KEY(customerID) references customers(customerID) 
, FOREIGN KEY(productID) references product(productID)
, PRIMARY KEY(customerID, productID)
);

drop table if exists billAddress;

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

drop table if exists shipAddress;

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

drop table if exists manifest;

CREATE TABLE [manifest] (
  [orderID] INTEGER NOT NULL
, [productID] INTEGER NOT NULL
, [qty] INTEGER NOT NULL
, FOREIGN KEY(orderID) references orderHistory(orderID)
, FOREIGN KEY(productID) references product(productID)
, PRIMARY KEY(orderID, productID)
);

drop table if exists orderHistory;

CREATE TABLE [orderHistory] (
  [orderID] INTEGER NOT NULL PRIMARY KEY
, [customerID] INTEGER NOT NULL
, [poNum] TEXT NOT NULL
, [trackNum] TEXT NOT NULL DEFAULT ''
, [shipType] TEXT NOT NULL DEFAULT ''
, [shipDate] DATE NOT NULL DEFAULT CURRENT_DATE
, FOREIGN KEY(customerID) references customers(customerID)
);

drop table if exists serialNumbers;

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
