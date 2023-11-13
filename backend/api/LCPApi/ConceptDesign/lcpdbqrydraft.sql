drop database lcpdb;
create database lcpdb;
use lcpdb;

create table Customers (
   customersid int PRIMARY KEY auto_increment,
   customersname varchar(255) not null,
   customerspass varchar(255) not null,
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
   employeespass varchar(255) not null,
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
   FOREIGN KEY (customersid) REFERENCES Customers(customersid),
   FOREIGN KEY (employeesid) REFERENCES employees(employeesid)
);

create table OrdersCustomers (
    ordersid int primary key auto_increment,
    customersid int null,
    CONSTRAINT UC_Orders UNIQUE (ordersid, customersid),
    FOREIGN KEY (customersid) REFERENCES Customers(customersid)
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
    FOREIGN KEY (ordersid) REFERENCES OrdersCustomers(ordersid),
    FOREIGN KEY (productsid) REFERENCES Products(productsid)
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
    FOREIGN KEY (customersid) REFERENCES Customers(customersid),
    FOREIGN KEY (employeesid) REFERENCES employees(employeesid),
    FOREIGN KEY (productsid) REFERENCES Products(productsid)
);

create table ProductsSubscriptions (
   productsid int primary key auto_increment,
   subsid int null,
   CONSTRAINT UC_ProductsSubscriptions UNIQUE (productsid, subsid),
   FOREIGN KEY (productsid) REFERENCES Products(productsid)
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
    FOREIGN KEY (subsid) REFERENCES Subscriptions(subsid)
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
    CONSTRAINT UC_Projects UNIQUE (projectsid)
);

create table Category (
	categoryid int primary key auto_increment,
    catdesc varchar(255) null,
    projectsid int null,
    CONSTRAINT UC_Category UNIQUE (categoryid, projectsid),
    FOREIGN KEY (projectsid) REFERENCES Projects(projectsid)
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
	FOREIGN KEY (projectsid) REFERENCES Projects(projectsid),
	FOREIGN KEY (categoryid) REFERENCES Category(categoryid)
);

create table TaskTypes (
	taskstypeid int primary key auto_increment,
    taskstypedesc varchar(255) null,
    tasksid int null,
    CONSTRAINT UC_TaskTypes UNIQUE (taskstypeid, tasksid),
    FOREIGN KEY (tasksid) REFERENCES Tasks(tasksid)
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
    FOREIGN KEY (tasksid) REFERENCES Tasks(tasksid),
	FOREIGN KEY (categoryid) REFERENCES Category(categoryid)
);

create table ProductsProjects (
	productsid int primary key auto_increment,
    projectsid int null,
    CONSTRAINT UC_ProductsProjects UNIQUE (productsid, projectsid),
    FOREIGN KEY (projectsid) REFERENCES Projects(projectsid)
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
    FOREIGN KEY (customersid) REFERENCES Customers(customersid),
    FOREIGN KEY (projectsid) REFERENCES Projects(projectsid)
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
    FOREIGN KEY (feedbackid) REFERENCES Feedback(feedbackid),
    FOREIGN KEY (customersid) REFERENCES Customers(customersid),
    FOREIGN KEY (employeesid) REFERENCES employees(employeesid)
);

create table Departament (
    departamentid int primary key auto_increment,
    departamentname varchar(255) not null,
    departamenttype varchar(255) null,
    departamentdesc varchar(255) null,
    projectsid int null,
    employeesid int null,
    CONSTRAINT UC_Departament UNIQUE (departamentid, projectsid, employeesid),
    FOREIGN KEY (projectsid) REFERENCES Projects(projectsid),
    FOREIGN KEY (employeesid) REFERENCES employees(employeesid)
);