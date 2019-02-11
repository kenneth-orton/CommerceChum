drop table customers;
drop table product;
drop table billAddress;
drop table shipAddress;
drop table manifest;
drop table orderHistory;

CREATE TABLE [product] (
  [productID] INTEGER NOT NULL PRIMARY KEY
, [name] TEXT NOT NULL DEFAULT ''
, [description] TEXT NOT NULL DEFAULT ''
, [price] double(10, 2) NOT NULL
, [active] bit NOT NULL DEFAULT 1
--, CONSTRAINT [PK_products] PRIMARY KEY ([productID])
);

CREATE TABLE [customers] (
  [customerID] INTEGER NOT NULL PRIMARY KEY
, [companyName] TEXT NOT NULL DEFAULT ''
, [payTerms] TEXT NOT NULL DEFAULT ''
, [addressSame] bit NOT NULL DEFAULT 1
, [active] bit NOT NULL DEFAULT 1
);

CREATE TABLE [billAddress] (
  [customerID] INTEGER NOT NULL PRIMARY KEY
, [billContactName] TEXT NOT NULL DEFAULT ''
, [billAddr1] TEXT DEFAULT ''
, [billAddr2] TEXT DEFAULT ''
, [billCity] TEXT DEFAULT ''
, [billState] TEXT DEFAULT ''
, [billZip] TEXT DEFAULT ''
, [billCountry] TEXT DEFAULT ''
, [billPhoneNo] TEXT DEFAULT ''
, FOREIGN KEY(customerID) references customers(customerID) 
);

CREATE TABLE [shipAddress] (
  [customerID] INTEGER NOT NULL PRIMARY KEY
, [shipContactName] TEXT NOT NULL DEFAULT ''
, [shipAddr1] TEXT DEFAULT ''
, [shipAddr2] TEXT DEFAULT ''
, [shipCity] TEXT DEFAULT ''
, [shipState] TEXT DEFAULT ''
, [shipZip] TEXT DEFAULT ''
, [shipCountry] TEXT DEFAULT ''
, [shipPhoneNo] TEXT DEFAULT ''
, FOREIGN KEY(customerID) references customers(customerID) 
);

CREATE TABLE [manifest] (
  [id] INTEGER NOT NULL PRIMARY KEY
, [manifestID] INTEGER NOT NULL
, [productID] INTEGER NOT NULL
, [qty] INTEGER NOT NULL
, FOREIGN KEY(manifestID) references orderHistory(manifestID)
, FOREIGN KEY(productID) references products(productID)
);

CREATE TABLE [orderHistory] (
  [orderID] INTEGER NOT NULL PRIMARY KEY
, [poNum] INTEGER
, [trackNum] INTEGER
, [shipCarrier] TEXT
, [customerID] INTEGER NOT NULL
, [manifestID] INTEGER NOT NULL
, FOREIGN KEY(orderID) references orderHistory(orderID)
, FOREIGN KEY(customerID) references customers(customerID)
);