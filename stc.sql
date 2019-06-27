-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Jun 26, 2019 at 09:48 AM
-- Server version: 5.7.24
-- PHP Version: 5.6.40

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `stc`
--

-- --------------------------------------------------------

--
-- Table structure for table `mail_model`
--

DROP TABLE IF EXISTS `mail_model`;
CREATE TABLE IF NOT EXISTS `mail_model` (
  `Id` int(11) NOT NULL,
  `Title` varchar(255) DEFAULT NULL,
  `Type` int(11) DEFAULT NULL,
  `Context` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `mail_type`
--

DROP TABLE IF EXISTS `mail_type`;
CREATE TABLE IF NOT EXISTS `mail_type` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Type` int(255) DEFAULT NULL,
  `SonType` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `mail_type`
--

INSERT INTO `mail_type` (`Id`, `Name`, `Type`, `SonType`) VALUES
(1, '年假', 1, 'null'),
(2, '事假', 1, 'null'),
(3, '外勤', 2, 'null');

-- --------------------------------------------------------

--
-- Table structure for table `sys_department`
--

DROP TABLE IF EXISTS `sys_department`;
CREATE TABLE IF NOT EXISTS `sys_department` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `Leader` int(255) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sys_department`
--

INSERT INTO `sys_department` (`Id`, `Name`, `Leader`) VALUES
(2, '产品研发部', 0);

-- --------------------------------------------------------

--
-- Table structure for table `sys_position`
--

DROP TABLE IF EXISTS `sys_position`;
CREATE TABLE IF NOT EXISTS `sys_position` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) DEFAULT NULL,
  `department` int(255) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `deparment` (`department`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sys_position`
--

INSERT INTO `sys_position` (`Id`, `Name`, `department`) VALUES
(1, '软件工程师', 2);

-- --------------------------------------------------------

--
-- Table structure for table `sys_userinfo`
--

DROP TABLE IF EXISTS `sys_userinfo`;
CREATE TABLE IF NOT EXISTS `sys_userinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(50) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Phone` varchar(100) NOT NULL,
  `Position` int(255) DEFAULT NULL,
  `Email` varchar(200) NOT NULL,
  `Department` int(200) NOT NULL,
  `Authority` int(11) NOT NULL DEFAULT '0',
  `LastLogin` varchar(200) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `sys_userinfo`
--

INSERT INTO `sys_userinfo` (`Id`, `UserName`, `Password`, `Phone`, `Position`, `Email`, `Department`, `Authority`, `LastLogin`) VALUES
(1, '刘键汉', '123456', '15521140920', 2, 'liujh@strongtech.net.cn', 2, 2, '2019/6/25 21:39:14');

-- --------------------------------------------------------

--
-- Table structure for table `user_mail`
--

DROP TABLE IF EXISTS `user_mail`;
CREATE TABLE IF NOT EXISTS `user_mail` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(255) DEFAULT NULL,
  `UserId` int(20) DEFAULT NULL,
  `CrateDate` datetime DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Reason` varchar(500) DEFAULT NULL,
  `StartDate` varchar(200) DEFAULT NULL,
  `EndDate` varchar(200) DEFAULT NULL,
  `Location` varchar(20) DEFAULT NULL,
  `PeopleNum` int(11) DEFAULT NULL,
  `SumDay` float(10,0) NOT NULL,
  `Status` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `ID` (`UserId`)
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `user_mail`
--

INSERT INTO `user_mail` (`Id`, `Type`, `UserId`, `CrateDate`, `Reason`, `StartDate`, `EndDate`, `Location`, `PeopleNum`, `SumDay`, `Status`) VALUES
(1, '1', 1, NULL, '3231', '2019-06-25全天', '2019-06-26全天', NULL, NULL, 2, 0),
(2, '1', 1, '2019-06-25 21:39:53', '2312321', '2019-06-25全天', '2019-06-26全天', NULL, NULL, 2, 0),
(3, '1', 1, '2019-06-25 21:40:29', '321323', '2019-06-25全天', '2019-06-26全天', NULL, NULL, 2, 0),
(4, '1', 1, '2019-06-25 21:41:09', '3213123', '2019-06-25全天', '2019-06-26全天', NULL, NULL, 2, 0),
(5, '1', 1, '2019-06-25 21:41:33', '323', '2019-06-25全天', '2019-06-26全天', NULL, NULL, 2, 0),
(6, '1', 1, '2019-06-25 21:43:54', '4241234', '2019-06-25全天', '2019-06-26全天', NULL, NULL, 2, 0),
(7, '1', 1, '2019-06-25 21:48:22', '321321', '2019-06-25全天', '2019-06-26全天', NULL, NULL, 2, 0),
(8, '1', 1, '2019-06-25 21:48:37', '3213', '2019-06-25全天', '2019-06-26全天', NULL, NULL, 2, 0),
(9, '1', 1, '2019-06-25 21:49:09', '1232', '2019-06-25全天', '2019-06-26全天', NULL, NULL, 2, 0);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
