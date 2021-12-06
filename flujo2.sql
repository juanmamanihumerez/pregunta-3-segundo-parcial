-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Servidor: localhost
-- Tiempo de generación: 06-12-2021 a las 10:35:08
-- Versión del servidor: 8.0.18
-- Versión de PHP: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `flujo2`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `flujocondicionante`
--

CREATE TABLE `flujocondicionante` (
  `flujo` varchar(3) COLLATE utf8mb4_general_ci NOT NULL,
  `proceso` varchar(3) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `Si` varchar(3) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `No` varchar(3) COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `flujocondicionante`
--

INSERT INTO `flujocondicionante` (`flujo`, `proceso`, `Si`, `No`) VALUES
('', 'P4', 'P5', 'P6'),
('F1', 'P4', 'P5', 'P6');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `flujoproceso`
--

CREATE TABLE `flujoproceso` (
  `flujo` varchar(3) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `proceso` varchar(3) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `tipo` varchar(1) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `rol` varchar(15) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `procesosiguiente` varchar(3) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `formulario` varchar(20) COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `flujoproceso`
--

INSERT INTO `flujoproceso` (`flujo`, `proceso`, `tipo`, `rol`, `procesosiguiente`, `formulario`) VALUES
('F1', 'P1', 'I', 'Usuario', 'P2', 'fechahora'),
('F1', 'P2', 'P', 'Usuario', 'P3', 'listadoc'),
('F1', 'P3', 'D', 'Usuario', 'P4', 'presentardoc'),
('F1', 'P4', 'C', 'Kardex', NULL, 'docaldia'),
('F1', 'P5', 'F', 'Kardex', NULL, 'notifica'),
('F1', 'P6', 'P', 'Kardex', 'P7', 'informa'),
('F1', 'P7', 'P', 'Kardex', 'P8', 'anotar');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `seguimiento`
--

CREATE TABLE `seguimiento` (
  `notramite` int(11) DEFAULT NULL,
  `usuario` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `flujo` varchar(3) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `proceso` varchar(3) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `fechainicio` datetime DEFAULT NULL,
  `fechafin` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `seguimiento`
--

INSERT INTO `seguimiento` (`notramite`, `usuario`, `flujo`, `proceso`, `fechainicio`, `fechafin`) VALUES
(100, 'Juan', 'F1', 'P1', '2021-10-13 10:00:00', '2021-10-13 12:00:00'),
(100, 'Juan', 'F1', 'P2', '2021-10-13 12:00:00', NULL),
(101, 'Marcelo', 'F1', 'P1', '2021-10-13 10:00:00', '2021-10-13 12:00:00'),
(101, 'Marcelo', 'F1', 'P2', '2021-10-13 12:00:00', NULL),
(102, 'Ana', 'F2', 'P1', '2021-10-13 08:00:00', '2021-10-13 10:00:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuarios`
--

CREATE TABLE `usuarios` (
  `usuario` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `contrasenia` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL,
  `rol` varchar(10) COLLATE utf8mb4_general_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `usuarios`
--

INSERT INTO `usuarios` (`usuario`, `contrasenia`, `rol`) VALUES
('Juan', '123456', 'E'),
('Marcelo', '123456', 'E'),
('Ana', '123456', 'K');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
