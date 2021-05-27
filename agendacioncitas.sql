-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 27-05-2021 a las 02:06:11
-- Versión del servidor: 10.4.18-MariaDB
-- Versión de PHP: 7.4.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `agendacioncitas`
--
CREATE DATABASE IF NOT EXISTS `agendacioncitas` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `agendacioncitas`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `area`
--

DROP TABLE IF EXISTS `area`;
CREATE TABLE `area` (
  `ARE_ID` int(11) NOT NULL,
  `CLI_ID` int(11) NOT NULL,
  `ARE_NOMBRE` char(60) DEFAULT NULL,
  `ARE_ESTADO` char(1) DEFAULT 'A'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `area`
--

INSERT INTO `area` (`ARE_ID`, `CLI_ID`, `ARE_NOMBRE`, `ARE_ESTADO`) VALUES
(1, 1, 'Odontologia General', 'A'),
(2, 1, 'farmacia', 'A'),
(3, 2, 'luisjjj', 'I'),
(4, 1, 'area3tt', 'I'),
(5, 1, 'prueba34', 'I');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cita`
--

DROP TABLE IF EXISTS `cita`;
CREATE TABLE `cita` (
  `CIT_ID` int(11) NOT NULL,
  `CLI_ID` int(11) NOT NULL,
  `ARE_ID` int(11) NOT NULL,
  `DOC_ID` int(11) NOT NULL,
  `PAC_ID` int(11) NOT NULL,
  `CIT_FECHA` date DEFAULT NULL,
  `CIT_HORA` time DEFAULT NULL,
  `CIT_ESTADO` char(1) DEFAULT 'A'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `cita`
--

INSERT INTO `cita` (`CIT_ID`, `CLI_ID`, `ARE_ID`, `DOC_ID`, `PAC_ID`, `CIT_FECHA`, `CIT_HORA`, `CIT_ESTADO`) VALUES
(1, 1, 1, 1, 1, '2021-05-10', '00:00:00', 'A'),
(2, 1, 1, 1, 1, '2021-05-10', '11:00:00', 'I'),
(3, 1, 1, 1, 1, '2021-05-10', '12:00:00', 'A'),
(4, 1, 1, 1, 2, '0000-00-00', '14:30:00', 'I'),
(5, 1, 1, 1, 2, '0000-00-00', '09:00:00', 'I'),
(6, 1, 1, 1, 2, '2021-05-27', '12:00:00', 'I'),
(7, 1, 1, 1, 2, '2021-05-26', '10:00:00', 'A'),
(8, 1, 1, 1, 2, '2021-05-26', '14:00:00', 'A'),
(9, 1, 1, 1, 2, '2021-05-29', '11:00:00', 'A'),
(10, 1, 1, 1, 2, '2021-05-26', '13:00:00', 'A'),
(11, 1, 1, 1, 2, '2021-05-28', '13:30:00', 'A'),
(12, 1, 1, 1, 2, '2021-05-28', '12:00:00', 'A'),
(13, 1, 1, 3, 2, '2021-05-29', '13:30:00', 'A'),
(14, 1, 1, 8, 2, '2021-05-31', '13:00:00', 'A'),
(15, 1, 1, 8, 2, '2021-06-18', '12:30:00', 'A'),
(16, 1, 1, 8, 2, '2021-05-28', '18:00:00', 'A'),
(17, 1, 1, 1, 2, '2021-05-27', '12:30:00', 'A'),
(18, 1, 1, 8, 2, '2021-05-28', '13:30:00', 'A'),
(19, 1, 1, 8, 2, '2021-05-28', '14:00:00', 'A'),
(20, 1, 1, 8, 2, '2021-05-31', '14:00:00', 'A'),
(21, 1, 1, 8, 7, '2021-05-28', '14:00:00', 'A'),
(22, 1, 1, 8, 4, '2021-06-30', '16:00:00', 'A');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clinica`
--

DROP TABLE IF EXISTS `clinica`;
CREATE TABLE `clinica` (
  `CLI_ID` int(11) NOT NULL,
  `CLI_NOMBRE` char(50) DEFAULT NULL,
  `CLI_DIRECCION` char(50) DEFAULT NULL,
  `CLI_CORREO` char(50) DEFAULT NULL,
  `CLI_TELEFONO` char(10) DEFAULT NULL,
  `CLI_PAGINA_WEB` char(100) DEFAULT NULL,
  `CLI_REPRESENTANTE_LEGAL` char(100) DEFAULT NULL,
  `CLI_PAIS` varchar(100) DEFAULT NULL,
  `CLI_ESTADO` char(1) DEFAULT 'A'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `clinica`
--

INSERT INTO `clinica` (`CLI_ID`, `CLI_NOMBRE`, `CLI_DIRECCION`, `CLI_CORREO`, `CLI_TELEFONO`, `CLI_PAGINA_WEB`, `CLI_REPRESENTANTE_LEGAL`, `CLI_PAIS`, `CLI_ESTADO`) VALUES
(1, 'Odofarmet', 'S58E entre calle A y, B, Quito 170132', 'odofarmed@gmail.com', '0984090023', 'https://www.facebook.com/Unidad-de-Salud-Odofarmed-101787258286146', 'Adriana Ninahualpa', '', 'A'),
(2, 'Odofarmet 2', 'S58E entre calle A y, B, Quito 170132', 'odofarmed@gmail.com', '0984090023', 'https://www.facebook.com/Unidad-de-Salud-Odofarmed-101787258286146', 'Adriana Ninahualpa', '', 'I'),
(3, 'Odofarmet 2', 'S58E entre calle A y, B, Quito 170132', 'odofarmed@gmail.com', '0984090023', 'https://www.facebook.com/Unidad-de-Salud-Odofarmed-101787258286146', 'Adriana Ninahualpa', '', 'I'),
(4, 'FARN1', 'EL CONDE1', 'CONDE1', 'CONDE1', 'MIG1', 'dd1', 'Algeria', 'I'),
(5, 'gggg1', 'gggg1', 'gggg', 'gggg', 'hhhh', 'dddd', 'Angola', 'I'),
(6, 'ado21', 'el conde', 'kiurt', 'dddd', 'llll', 'dew', 'Afghanistan', 'I'),
(7, 'odfe1', 'sdf1', 'sdaf1', 'sdaf1', '1fgffd', 'fdfg', 'Armenia', 'I'),
(8, 'Odontoto1', 'jsdaflf', 'sdfdsf', 'sdsdfdf', 'mifjsaodifj', 'dsfg', 'Andorra', 'I');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `doctor`
--

DROP TABLE IF EXISTS `doctor`;
CREATE TABLE `doctor` (
  `DOC_ID` int(11) NOT NULL,
  `CLI_ID` int(11) NOT NULL,
  `ARE_ID` int(11) DEFAULT NULL,
  `USU_ID` int(11) NOT NULL,
  `DOC_PRIMER_NOMBRE` char(20) DEFAULT NULL,
  `DOC_SEGUNDO_NOMBRE` char(20) DEFAULT NULL,
  `DOC_PRIMER_APELLIDO` char(20) DEFAULT NULL,
  `DOC_SEGUNDO_APELLIDO` char(20) DEFAULT NULL,
  `DOC_CEDULA` char(10) DEFAULT NULL,
  `DOC_CORREO` char(50) DEFAULT NULL,
  `DOC_TELEFONO` char(50) DEFAULT NULL,
  `DOC_ESTADO` char(1) DEFAULT 'A'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `doctor`
--

INSERT INTO `doctor` (`DOC_ID`, `CLI_ID`, `ARE_ID`, `USU_ID`, `DOC_PRIMER_NOMBRE`, `DOC_SEGUNDO_NOMBRE`, `DOC_PRIMER_APELLIDO`, `DOC_SEGUNDO_APELLIDO`, `DOC_CEDULA`, `DOC_CORREO`, `DOC_TELEFONO`, `DOC_ESTADO`) VALUES
(1, 1, 1, 1, 'Adriana', 'Lisbeth', 'Ninahualpa', 'Aguiar', '172514851', 'adriafsafd', '098405487', 'A'),
(3, 0, 1, 4, 'anahiewwe1', 'lola', 'rogel', 'Moreta', '1726153426', 'roge@gmai.com', '0985866835', 'I'),
(4, 1, 1, 3, 'anahi', 'lola', 'rogel', 'Moreta', '1726153426', 'roge@gmai.com', '0985866835', 'I'),
(8, 1, 2, 18, 'Wendy', 'Estefania', 'Ninahualpa', 'Aguiar', '17254361', 'migadnoi', '099845461', 'A'),
(9, 0, NULL, 21, 'dfg', 'dfgfdg', '', '', '', '', '', 'I');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `paciente`
--

DROP TABLE IF EXISTS `paciente`;
CREATE TABLE `paciente` (
  `PAC_ID` int(11) NOT NULL,
  `USU_ID` int(11) NOT NULL,
  `PAC_PRIMER_NOMBRE` char(50) DEFAULT NULL,
  `PAC_SEGUNDO_NOMBRE` char(50) DEFAULT NULL,
  `PAC_PRIMER_APELLIDO` char(50) DEFAULT NULL,
  `PAC_SEGUNDO_APELLIDO` char(50) DEFAULT NULL,
  `PAC_CEDULA` char(10) DEFAULT NULL,
  `PAC_CORREO` char(50) DEFAULT NULL,
  `PAC_TELEFONO` char(10) DEFAULT NULL,
  `PAC_ESTADO` char(1) DEFAULT 'A'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `paciente`
--

INSERT INTO `paciente` (`PAC_ID`, `USU_ID`, `PAC_PRIMER_NOMBRE`, `PAC_SEGUNDO_NOMBRE`, `PAC_PRIMER_APELLIDO`, `PAC_SEGUNDO_APELLIDO`, `PAC_CEDULA`, `PAC_CORREO`, `PAC_TELEFONO`, `PAC_ESTADO`) VALUES
(1, 3, 'Jessica', 'Viviana', 'Cordova', 'Moreta', '175468951', 'cordovak@gmai.com', '0985866854', 'A'),
(2, 8, 'william', 'Miguel', 'Abad', 'Sarmient', '172548741', 'migue', '0875432', 'A'),
(3, 9, 'maria', 'beken', 'sof', 'carma', '1725132584', 'mig', '0984090044', 'A'),
(4, 10, 'jossue', 'abad', 'sarmiento', 'lui', '1725131245', 'sdfd', '0984151', 'A'),
(5, 13, 'dei', 'damaris', 'torres', 'lei', '12549884', 'mig_ninahsf', '0984156', 'A'),
(6, 22, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'A'),
(7, 23, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'A'),
(8, 24, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'A');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

DROP TABLE IF EXISTS `usuario`;
CREATE TABLE `usuario` (
  `USU_ID` int(11) NOT NULL,
  `USU_USUARIO` char(50) DEFAULT NULL,
  `USU_CLAVE` char(50) DEFAULT NULL,
  `USU_ROL` char(50) DEFAULT NULL,
  `USU_ESTADO` char(1) DEFAULT 'A'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`USU_ID`, `USU_USUARIO`, `USU_CLAVE`, `USU_ROL`, `USU_ESTADO`) VALUES
(1, 'admin', 'admin', 'ADMINISTRADOR', 'A'),
(2, 'william', 'clave', 'PACIENTE', 'A'),
(3, 'Sol', 'HEU88', 'PACIENTE', 'A'),
(4, 'kari1', '124', 'DOCTOR', 'A'),
(5, 'kari', '12345', 'PACIENTE', 'A'),
(6, 'usuario1', 'usuario1', 'PACIENTE', 'A'),
(7, 'jess', '12345', 'PACIENTE', 'A'),
(8, 'Miguelito', '12345', 'PACIENTE', 'A'),
(9, 'mabe', '123', 'PACIENTE', 'A'),
(10, 'jossue', '12345', 'PACIENTE', 'A'),
(11, 'admin1', 'admin1', 'ADMINISTRADOR', 'A'),
(12, 'xzczxc1', 'zxcxzc1', 'ADMINISTRADOR', 'I'),
(13, 'dtorres', '12345', 'PACIENTE', 'A'),
(15, 'dsf', 'sfdf', 'ADMINISTRADOR', 'A'),
(18, 'wendy', 'wendy', 'DOCTOR', 'A'),
(19, 'adminaitradornuevo', 'admint4', 'ADMINISTRADOR', 'I'),
(20, 'dfdfd', 'sdfdsfs', 'ADMINISTRADOR', 'I'),
(21, 'fdg', 'sdfds', 'DOCTOR', 'A'),
(22, 'joew2', 'joew2', 'PACIENTE', 'A'),
(23, 'luis1d', '12345', 'PACIENTE', 'A'),
(24, 'jossue', '12345', 'PACIENTE', 'A');

--
-- Disparadores `usuario`
--
DROP TRIGGER IF EXISTS `INGRESAR_PACIENTE`;
DELIMITER $$
CREATE TRIGGER `INGRESAR_PACIENTE` AFTER INSERT ON `usuario` FOR EACH ROW BEGIN
if new.USU_ROL="PACIENTE" THEN BEGIN
INSERT INTO paciente (USU_ID) values (NEW.USU_ID);
END; end IF;
if new.USU_ROL="DOCTOR" THEN BEGIN
INSERT INTO doctor (USU_ID) values (NEW.USU_ID);
END; end IF;
END
$$
DELIMITER ;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `area`
--
ALTER TABLE `area`
  ADD PRIMARY KEY (`ARE_ID`),
  ADD KEY `FK_RELATIONSHIP_4` (`CLI_ID`);

--
-- Indices de la tabla `cita`
--
ALTER TABLE `cita`
  ADD PRIMARY KEY (`CIT_ID`),
  ADD KEY `FK_RELATIONSHIP_6` (`DOC_ID`),
  ADD KEY `FK_RELATIONSHIP_7` (`PAC_ID`);

--
-- Indices de la tabla `clinica`
--
ALTER TABLE `clinica`
  ADD PRIMARY KEY (`CLI_ID`);

--
-- Indices de la tabla `doctor`
--
ALTER TABLE `doctor`
  ADD PRIMARY KEY (`DOC_ID`),
  ADD KEY `FK_REFERENCE_5` (`USU_ID`),
  ADD KEY `FK_RELATIONSHIP_5` (`ARE_ID`);

--
-- Indices de la tabla `paciente`
--
ALTER TABLE `paciente`
  ADD PRIMARY KEY (`PAC_ID`),
  ADD KEY `FK_REFERENCE_6` (`USU_ID`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`USU_ID`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `area`
--
ALTER TABLE `area`
  MODIFY `ARE_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT de la tabla `cita`
--
ALTER TABLE `cita`
  MODIFY `CIT_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT de la tabla `clinica`
--
ALTER TABLE `clinica`
  MODIFY `CLI_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `doctor`
--
ALTER TABLE `doctor`
  MODIFY `DOC_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de la tabla `paciente`
--
ALTER TABLE `paciente`
  MODIFY `PAC_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `USU_ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=25;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `area`
--
ALTER TABLE `area`
  ADD CONSTRAINT `FK_RELATIONSHIP_4` FOREIGN KEY (`CLI_ID`) REFERENCES `clinica` (`CLI_ID`);

--
-- Filtros para la tabla `cita`
--
ALTER TABLE `cita`
  ADD CONSTRAINT `FK_RELATIONSHIP_6` FOREIGN KEY (`DOC_ID`) REFERENCES `doctor` (`DOC_ID`),
  ADD CONSTRAINT `FK_RELATIONSHIP_7` FOREIGN KEY (`PAC_ID`) REFERENCES `paciente` (`PAC_ID`);

--
-- Filtros para la tabla `doctor`
--
ALTER TABLE `doctor`
  ADD CONSTRAINT `FK_REFERENCE_5` FOREIGN KEY (`USU_ID`) REFERENCES `usuario` (`USU_ID`),
  ADD CONSTRAINT `FK_RELATIONSHIP_5` FOREIGN KEY (`ARE_ID`) REFERENCES `area` (`ARE_ID`);

--
-- Filtros para la tabla `paciente`
--
ALTER TABLE `paciente`
  ADD CONSTRAINT `FK_REFERENCE_6` FOREIGN KEY (`USU_ID`) REFERENCES `usuario` (`USU_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
