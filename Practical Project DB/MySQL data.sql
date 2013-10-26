-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Хост: localhost
-- Време на генериране: 
-- Версия на сървъра: 5.5.24-log
-- Версия на PHP: 5.4.3

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- БД: `supermarketinformation`
--

-- --------------------------------------------------------

--
-- Структура на таблица `measures`
--

CREATE TABLE IF NOT EXISTS `measures` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `MeasureName` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Ссхема на данните от таблица `measures`
--

INSERT INTO `measures` (`ID`, `MeasureName`) VALUES
(1, 'liters'),
(2, 'peices');

-- --------------------------------------------------------

--
-- Структура на таблица `products`
--

CREATE TABLE IF NOT EXISTS `products` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Vendors_ID` int(11) NOT NULL,
  `ProductName` varchar(45) NOT NULL,
  `Measures_ID` int(11) NOT NULL,
  `BasePrice` decimal(10,2) NOT NULL,
  PRIMARY KEY (`ID`,`Vendors_ID`,`Measures_ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`),
  KEY `fk_Products_Vendors_idx` (`Vendors_ID`),
  KEY `fk_Products_Measures1_idx` (`Measures_ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Ссхема на данните от таблица `products`
--

INSERT INTO `products` (`ID`, `Vendors_ID`, `ProductName`, `Measures_ID`, `BasePrice`) VALUES
(1, 2, 'Beer “Zagorka”', 1, '0.86'),
(2, 3, 'Vodka “Targovishte”', 1, '7.56'),
(3, 2, 'Beer “Beck’s”', 1, '1.03'),
(4, 1, 'Chocolate “Milka”', 2, '2.80');

-- --------------------------------------------------------

--
-- Структура на таблица `vendors`
--

CREATE TABLE IF NOT EXISTS `vendors` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `VendorName` varchar(45) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID_UNIQUE` (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Ссхема на данните от таблица `vendors`
--

INSERT INTO `vendors` (`ID`, `VendorName`) VALUES
(1, 'Nestle Sofia Corp.'),
(2, 'Zagorka Corp.'),
(3, 'Targovishte Bottling Company Ltd.');

--
-- Ограничения за дъмпнати таблици
--

--
-- Ограничения за таблица `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk_Products_Vendors` FOREIGN KEY (`Vendors_ID`) REFERENCES `vendors` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  ADD CONSTRAINT `fk_Products_Measures1` FOREIGN KEY (`Measures_ID`) REFERENCES `measures` (`ID`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
