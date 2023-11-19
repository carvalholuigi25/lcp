drop database lcpdb;
create database lcpdb;
use lcpdb;

create table Customers (
   customersid int PRIMARY KEY auto_increment,
   customersname varchar(255) not null,
   customerspass longtext not null,
   customersrole varchar(255) null default 'user',
   email varchar(255) not null,
   pin int null,
   firstname varchar(255) null,
   lastname varchar(255) null,
   datebirthday date null,
   dateregistered date null,
   country varchar(255) null,
   phonenumber varchar(255) null,
   postaladdress varchar(255) null,
   city varchar(255) null,
   zipcode varchar(255) null,
   stateprovince varchar(255) null,
   CONSTRAINT UC_Customers UNIQUE (customersid)
);

create table Employees (
   employeesid int primary key auto_increment,
   employeesname varchar(255) not null,
   employeespass longtext not null,
   employeesrole varchar(255) null default 'vendor',
   email varchar(255) not null,
   pin int null,
   firstname varchar(255) null,
   lastname varchar(255) null,
   datebirthday date null,
   dateregistered date null,
   country varchar(255) null,
   phonenumber varchar(255) null,
   postaladdress varchar(255) null,
   city varchar(255) null,
   zipcode varchar(255) null,
   stateprovince varchar(255) null,
   CONSTRAINT UC_Employees UNIQUE (employeesid)
);

create table Products (
   productsid int primary key auto_increment,
   prodtitle varchar(255) not null,
   prodtype varchar(255) not null,
   proddesc varchar(255) null,
   prodprice real null,
   prodimgmain varchar(255) null,
   prodgallery varchar(255) null,
   prodisfeatured boolean null,
   proddatecreated date null,
   proddateupdated date null,
   customersid int null,
   employeesid int null,
   CONSTRAINT UC_Products UNIQUE (productsid, customersid, employeesid),
   FOREIGN KEY (customersid) REFERENCES Customers(customersid) ON UPDATE CASCADE ON DELETE CASCADE,
   FOREIGN KEY (employeesid) REFERENCES employees(employeesid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table OrdersCustomers (
    ordersid int primary key auto_increment,
    customersid int null,
    CONSTRAINT UC_Orders UNIQUE (ordersid, customersid),
    FOREIGN KEY (customersid) REFERENCES Customers(customersid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table Orders (
	ordersid int primary key auto_increment,
    productsid int null,
    quantity int null,
    orderdate date null,
    itemprice double null,
    itemdiscount int null,
    itemstock int null,
    CONSTRAINT UC_Orders UNIQUE (ordersid, productsid),
    FOREIGN KEY (ordersid) REFERENCES OrdersCustomers(ordersid) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (productsid) REFERENCES Products(productsid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table Subscriptions (
    subsid int primary key auto_increment,
    substitle varchar(255) not null,
    subsdesc varchar(255) null,
    substype varchar(255) null,
    subsimg varchar(255) null,
    subsdatepurchased date null,
    subsdateended date null,
    subsisexpired boolean null,
    customersid int null,
    employeesid int null,
    productsid int null,
    CONSTRAINT UC_Subscriptions UNIQUE (subsid, customersid, employeesid, productsid),
    FOREIGN KEY (customersid) REFERENCES Customers(customersid) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (employeesid) REFERENCES employees(employeesid) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (productsid) REFERENCES Products(productsid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table ProductsSubscriptions (
   productsid int primary key auto_increment,
   subsid int null,
   CONSTRAINT UC_ProductsSubscriptions UNIQUE (productsid, subsid),
   FOREIGN KEY (productsid) REFERENCES Products(productsid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table SubscriptionsKeys (
	keysid int primary key auto_increment,
    keysvalue text not null,
    keysdatestart date null,
    keysdateexp date null,
    keysdateupdated date null,
    keysstatus enum('pending', 'granted', 'expired', 'revoked', 'unknown') null default 'pending',
    subsid int null,
    CONSTRAINT UC_SubscriptionsKeys UNIQUE (keysid, subsid),
    FOREIGN KEY (subsid) REFERENCES Subscriptions(subsid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table Projects (
    projectsid int primary key auto_increment,
    projname varchar(255) not null,
    projdesc varchar(255) not null,
    projcompany varchar(255) not null,
    projowner varchar(255) not null,
    projcategory varchar(255) null,
    projpriority boolean null,
    projstatus enum('pending', 'delivered', 'approved', 'rejected', 'delayed', 'cancelled') null default 'pending',
    projstartdate date null,
    projenddate date null,
    projclosedate date null,
    projbudgetdays int null,
    projbudgetcost double null,
    projrecords varchar(255) null,
    employeesid int null,
    CONSTRAINT UC_Projects UNIQUE (projectsid),
    FOREIGN KEY (employeesid) REFERENCES Employees(employeesid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table Category (
	categoryid int primary key auto_increment,
    catdesc varchar(255) null,
    projectsid int null,
    CONSTRAINT UC_Category UNIQUE (categoryid, projectsid),
    FOREIGN KEY (projectsid) REFERENCES Projects(projectsid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table Tasks (
    tasksid int primary key auto_increment,
    taskname varchar(255) not null,
    taskdesc varchar(255) not null,
    taskproject varchar(255) not null,
    phasename varchar(255) not null,
    taskstatus enum('pending', 'accepted', 'delayed', 'cancelled') null default 'pending' null,
    taskowner varchar(255) null,
    tasktype varchar(255) null,
    taskpriority boolean null,
    taskstartdate date null,
    taskenddate date null,
    taskteam varchar(255) null,
    taskreviewdate date null,
    taskreviewreport text null,
    taskdocument text null,
    taskdetails text null,
    projectsid int null,
    categoryid int null,
    CONSTRAINT UC_Tasks UNIQUE (tasksid, projectsid, categoryid),
	FOREIGN KEY (projectsid) REFERENCES Projects(projectsid) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (categoryid) REFERENCES Category(categoryid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table TaskTypes (
	taskstypeid int primary key auto_increment,
    taskstypedesc varchar(255) null,
    tasksid int null,
    CONSTRAINT UC_TaskTypes UNIQUE (taskstypeid, tasksid),
    FOREIGN KEY (tasksid) REFERENCES Tasks(tasksid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table ProjectPhases (
	phasesid int primary key auto_increment,
	phasename varchar(255) not null,
    projname varchar(255) not null,
    phasedesc varchar(255) null,
    phasestatus boolean null,
    phasestartdate date null,
    phaseenddate date null,
    phaseactivities text null,
    tasksid int null,
    categoryid int null,
    CONSTRAINT UC_ProjectPhases UNIQUE (phasesid),
    FOREIGN KEY (tasksid) REFERENCES Tasks(tasksid) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (categoryid) REFERENCES Category(categoryid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table ProductsProjects (
	productsid int primary key auto_increment,
    projectsid int null,
    CONSTRAINT UC_ProductsProjects UNIQUE (productsid, projectsid),
    FOREIGN KEY (projectsid) REFERENCES Projects(projectsid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table Feedback (
    feedbackid int primary key auto_increment,
    feedbacktitle varchar(255) not null,
    feedbackmsg text not null,
    feedbackstatus enum('pending', 'accepted', 'denied', 'locked') null default 'pending',
    feedbackdatecreated date null,
    feedbackdateupdated date null,
    feedbackassignby varchar(255) null,
    feedbackupvotes int null,
    feedbackdownvotes int null,
    customersid int null,
    projectsid int null,
    commentsid int null,
    CONSTRAINT UC_Feedback UNIQUE (customersid, projectsid, commentsid),
    FOREIGN KEY (customersid) REFERENCES Customers(customersid) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (projectsid) REFERENCES Projects(projectsid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table FeedbackComments (
    commentsid int primary key auto_increment,
    commentsmsg text not null,
    commentsupvotes int null,
    commentsdownvotes int null,
    commentsstatus enum('pending', 'accepted', 'denied', 'locked') null default 'pending',
    commentsdatecreated date null,
    commentsdateupdated date null,
    feedbackid int null,
    customersid int null,
    employeesid int null,
    CONSTRAINT UC_FeedbackComments UNIQUE (commentsid, feedbackid, customersid),
    FOREIGN KEY (feedbackid) REFERENCES Feedback(feedbackid) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (customersid) REFERENCES Customers(customersid) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (employeesid) REFERENCES employees(employeesid) ON UPDATE CASCADE ON DELETE CASCADE
);

create table Departament (
    departamentid int primary key auto_increment,
    departamentname varchar(255) not null,
    departamenttype varchar(255) null,
    departamentdesc varchar(255) null,
    projectsid int null,
    employeesid int null,
    CONSTRAINT UC_Departament UNIQUE (departamentid, projectsid, employeesid),
    FOREIGN KEY (projectsid) REFERENCES Projects(projectsid) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (employeesid) REFERENCES employees(employeesid) ON UPDATE CASCADE ON DELETE CASCADE
);

INSERT INTO Customers (customersname, customerspass, email, customersrole) VALUES ('timmy', sha("timmy1234"), 'timmy2023@localhost.loc', 'user');
INSERT INTO Employees (employeesname, employeespass, email, employeesrole) VALUES ('admin', sha('admin1234'), 'luiscarvalho239@gmail.com', 'admin');
INSERT INTO OrdersCustomers (customersid) VALUES (1);
INSERT INTO Products (prodtitle, prodtype, customersid, employeesid) VALUES ('LCP Website', 'Website', 1, 1);
INSERT INTO Orders (productsid, quantity, orderdate, itemprice, itemdiscount, itemstock) VALUES (1, 1, '2023-11-16', 20, 0, 1);
INSERT INTO Subscriptions (substitle, customersid, employeesid, productsid) VALUES ('Ultimate', 1, 1, 1);
INSERT INTO SubscriptionsKeys (keysvalue, keysstatus, subsid) VALUES ('A1B2C3-D4E5G6-H7I8J9', 'granted', 1);
INSERT INTO ProductsSubscriptions (subsid) VALUES (1);
INSERT INTO Projects (projname, projdesc, projowner, projcompany, employeesid) VALUES ('Websites', 'LCP', 'admin', 'LCP', 1);
INSERT INTO Category (catdesc, projectsid) VALUES ("Websites", 1);
INSERT INTO Category (catdesc) VALUES ("Apps");
INSERT INTO Category (catdesc) VALUES ("Softwares");
INSERT INTO Tasks (taskname, taskdesc, taskproject, phasename, taskstatus, projectsid, categoryid) VALUES ("Finished the website", "website for LCP", "LCP Website", "Add the website", "accepted", 1, 1);
INSERT INTO TaskTypes (taskstypedesc, tasksid) VALUES ("Added the website for LCP", 1);
INSERT INTO ProjectPhases (phasename, projname, tasksid, categoryid) VALUES ('Add the website', 'LCP Website', 1, 1);
INSERT INTO ProductsProjects (projectsid) VALUES (1);
INSERT INTO Feedback (feedbacktitle, feedbackmsg, feedbackstatus, customersid, projectsid, commentsid) VALUES ('LCP Website', 'Add the website', 'accepted', 1, 1, 1);
INSERT INTO FeedbackComments (commentsmsg, feedbackid, customersid, employeesid) VALUES ('Ok, added!', 1, 1, 1);
INSERT INTO Departament (departamentname, projectsid, employeesid) VALUES ('Web development', 1, 1);

SELECT Employees.*, Projects.*, Products.*, Orders.*, Subscriptions.*, Feedback.*, Departament.*, Customers.* FROM Employees 
INNER JOIN Projects ON Employees.employeesid = Projects.employeesid 
INNER JOIN Products ON Employees.employeesid = Products.employeesid
INNER JOIN Orders ON Products.productsid = Orders.ordersid
INNER JOIN Subscriptions ON Employees.employeesid = Subscriptions.employeesid
INNER JOIN Feedback ON Projects.projectsid = Feedback.projectsid
INNER JOIN Departament ON Employees.employeesid = Departament.employeesid
INNER JOIN Customers ON Employees.employeesid = Customers.customersid;