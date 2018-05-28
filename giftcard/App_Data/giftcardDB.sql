/*
Navicat MySQL Data Transfer
Source Host     : localhost:3306
Source Database : giftcard
Target Host     : localhost:3306
Target Database : giftcard
Date: 2018-05-28 20:29:13
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for giftcard
-- ----------------------------
DROP TABLE IF EXISTS `giftcard`;
CREATE TABLE `giftcard` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `giftcardcode` varchar(200) DEFAULT NULL,
  `PromoId` int(11) DEFAULT NULL,
  `generatedate` varchar(200) DEFAULT NULL,
  `isused` varchar(5) DEFAULT '0',
  `useddate` varchar(200) DEFAULT NULL,
  `forcompany` varchar(200) DEFAULT NULL,
  `expireddate` varchar(200) DEFAULT '',
  `usedopenid` varchar(200) DEFAULT NULL,
  `usedmobile` varchar(200) DEFAULT NULL,
  `usedname` varchar(200) DEFAULT NULL,
  `amount` varchar(200) DEFAULT NULL,
  `enabled` varchar(200) DEFAULT '0',
  `jumpurl` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=430 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of giftcard
-- ----------------------------
INSERT INTO `giftcard` VALUES ('326', '450541615471', '2321357', '2018-01-27 20:25:17', '1', '2018-01-27', '兴业银行', '2018-12-31', 'okou5v6zJqXG1dSta-IjgTmxQ-dE', '15221336036', '沈朝晖', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('327', '987654321743', '2321357', '2018-01-27 20:25:19', '1', '2018-02-07', '兴业银行', '2018-12-31', 'okou5v6zJqXG1dSta-IjgTmxQ-dE', '15221336036', '沈朝晖', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('328', '278641365471', '2321357', '2018-01-27 20:25:19', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('329', '788574687437', '2321357', '2018-01-27 20:25:19', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('330', '473600118458', '2321357', '2018-01-27 20:25:19', '1', '2018-03-08', '兴业银行', '2018-12-31', 'okou5v3qywEMdkeRNG1shued79ow', '13764508476', '鲍小姐', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('331', '688257007114', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('332', '176033146278', '2321357', '2018-01-27 20:32:27', '1', '2018-02-07', '兴业银行', '2018-12-31', 'okou5v9iXovenarrYdoiDDmCghuI', '13820529015', '林章悦', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('333', '047444603357', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('334', '117170132520', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('335', '518481651028', '2321357', '2018-01-27 20:32:27', '1', '2018-02-08', '兴业银行', '2018-12-31', 'okou5vwxU5VJrcE7t36BzqaZCRb0', '13764480677', '赵瑾瑾', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('336', '420764776382', '2321357', '2018-01-27 20:32:27', '1', '2018-03-07', '兴业银行', '2018-12-31', 'okou5v0M9HRlBUQTuTsVrB7f4qog', '18016336018', '丛海涛', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('337', '685305086737', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('338', '556840330842', '2321357', '2018-01-27 20:32:27', '1', '2018-02-27', '兴业银行', '2018-12-31', 'okou5v3CjAqNW2UvuOGfrCLt99SE', '13764559674', '潘永亮', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('339', '888526710046', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('340', '263853437377', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('341', '825770783701', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('342', '866363132351', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('343', '381280100314', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('344', '722716328530', '2321357', '2018-01-27 20:32:27', '1', '2018-02-08', '兴业银行', '2018-12-31', 'okou5v9hIXmPjFONPytotb6pFRfI', '13917755336', '张谨沂', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('345', '864844341743', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('346', '244680272264', '2321357', '2018-01-27 20:32:27', '1', '2018-05-14', '兴业银行', '2018-12-31', 'okou5vw4insVfoUzBS9QJn_GWAYc', '18217773792', '戴萌萌', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('347', '140478887372', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('348', '400052051827', '2321357', '2018-01-27 20:32:27', '1', '2018-02-28', '兴业银行', '2018-12-31', 'okou5v6FdSHsjfmQj6AL9FmOYy_8', '17710037687', '徐中韩', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('349', '438286615222', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('350', '770127101607', '2321357', '2018-01-27 20:32:27', '1', '2018-04-05', '兴业银行', '2018-12-31', 'okou5vwLbC-Xhjw13he-D43JzcMs', '13816615811', '沈漪', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('351', '062043205008', '2321357', '2018-01-27 20:32:27', '1', '2018-02-28', '兴业银行', '2018-12-31', 'okou5v87FgjFBpUWvB76h7Ii1ZS0', '18502128245', '李琴', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('352', '506453515805', '2321357', '2018-01-27 20:32:27', '1', '2018-02-11', '兴业银行', '2018-12-31', 'okou5vwFlVPl3SpjQ5_l4rOdCdCo', '13918424798', '王哲彦', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('353', '621537480275', '2321357', '2018-01-27 20:32:27', '1', '2018-02-09', '兴业银行', '2018-12-31', 'okou5v198H-vDh9RWzB_pDqk4mBE', '18016050456', 'Elaine', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('354', '001672232371', '2321357', '2018-01-27 20:32:27', '1', '2018-03-07', '兴业银行', '2018-12-31', 'okou5v2LC_uSYdNSZKVd8EyJUpRg', '15800538215', '蒙坚玲', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('355', '265454773235', '2321357', '2018-01-27 20:32:27', '1', '2018-03-03', '兴业银行', '2018-12-31', 'okou5v4L5AoxdkWdyDUH6Sxc4PU0', '13801713531', '葛容汶', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('356', '367114151584', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('357', '231421686486', '2321357', '2018-01-27 20:32:27', '1', '2018-03-09', '兴业银行', '2018-12-31', 'okou5v6II22sNacEEf6J1W4ACnOY', '13761158895', '高高', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('358', '522446811143', '2321357', '2018-01-27 20:32:27', '1', '2018-03-08', '兴业银行', '2018-12-31', 'okou5v4bf-VsFa5iOQDhk10jPbeA', '13482869086', '许昕敏', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('359', '327533201377', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('360', '418460510255', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('361', '041420334011', '2321357', '2018-01-27 20:32:27', '1', '2018-05-17', '兴业银行', '2018-12-31', 'okou5v6Ozygbqc3ySln2RyZhdp20', '13901617173', '翁宵暐', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('362', '246658380276', '2321357', '2018-01-27 20:32:27', '1', '2018-03-02', '兴业银行', '2018-12-31', 'okou5v-ZpeqtrhRh-QF19VT3Enfg', '17701795118', '陈勇', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('363', '641722043478', '2321357', '2018-01-27 20:32:27', '1', '2018-02-07', '兴业银行', '2018-12-31', 'okou5v30lqVHQ8CtQ78Tn_HRAZWw', '18621992102', '陈晓晖', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('364', '143127803715', '2321357', '2018-01-27 20:32:27', '1', '2018-05-17', '兴业银行', '2018-12-31', 'okou5v9nclFZExVCMTNXz7wvPXfk', '18020830903', '刘韵平', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('365', '044864503547', '2321357', '2018-01-27 20:32:27', '1', '2018-03-07', '兴业银行', '2018-12-31', 'okou5v-VX5cO_F2OiAn1zUZphPOA', '15000337275', '吴姗', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('366', '784002272005', '2321357', '2018-01-27 20:32:27', '1', '2018-02-26', '兴业银行', '2018-12-31', 'okou5vwNodQELGHlP3VEz9voLM1o', '13788898766', '林苹', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('367', '415582206618', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('368', '733824317740', '2321357', '2018-01-27 20:32:27', '1', '2018-02-23', '兴业银行', '2018-12-31', 'okou5v8043JQXrRK7nXV7Ycy6cYA', '18516216341', '董奇琦', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('369', '648606104622', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('370', '607167482146', '2321357', '2018-01-27 20:32:27', '1', '2018-02-21', '兴业银行', '2018-12-31', 'okou5v1vfVu1AjOQbtzeY1WgbE00', '18918583368', '罗继平', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('371', '578358248585', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('372', '283746434305', '2321357', '2018-01-27 20:32:27', '1', '2018-03-01', '兴业银行', '2018-12-31', 'okou5v5W81TW-E2yvUdblpngtKQs', '18116332816', '顾新尔', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('373', '572324518383', '2321357', '2018-01-27 20:32:27', '1', '2018-03-03', '兴业银行', '2018-12-31', 'okou5v2R-bBSXxMawqJYc7rOdPFc', '18121253356', '王璐', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('374', '122654810862', '2321357', '2018-01-27 20:32:27', '1', '2018-03-04', '兴业银行', '2018-12-31', 'okou5v2yG3jAmu-Mi6FS6vXJVo9o', '13918293381', '乔海文', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('375', '876305527121', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('376', '554655372674', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('377', '881224475510', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('378', '223051183434', '2321357', '2018-01-27 20:32:27', '1', '2018-03-01', '兴业银行', '2018-12-31', 'okou5v5rh-ABodUROSOuXjP8grdA', '13524721897', '赵晶晶', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('379', '064015783243', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('380', '437765708543', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('381', '808223421516', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('382', '114342250565', '2321357', '2018-01-27 20:32:27', '1', '2018-02-09', '兴业银行', '2018-12-31', 'okou5vwJvzst0jOIQsakJB6ofI0s', '13818951963', '薛', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('383', '484645120766', '2321357', '2018-01-27 20:32:27', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('384', '831248240185', '2321357', '2018-01-27 20:32:28', '0', null, '兴业银行', '2018-12-31', null, null, null, '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('385', '826605376382', '2321357', '2018-01-27 20:32:28', '1', '2018-03-02', '兴业银行', '2018-12-31', 'okou5v7mHxv55qHIjyLShDv0-Qxw', '13761895687', '毕玉', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('386', '863247681874', '2321357', '2018-01-27 20:32:28', '1', '2018-03-08', '兴业银行', '2018-12-31', 'okou5v_aqtfpkWdRol335bcnWM8M', '13636311201', '贾小姐', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('401', '612218877252', '2321357', '2018-01-27 20:32:28', '1', '2018-02-07', '兴业银行', '2018-12-31', 'okou5v7onI4Cs0jYbPI9gD_zGdd8', '18512174675', '南洋', '398', '1', 'https://h5.youzan.com/v2/goods/3nlmson5926si');
INSERT INTO `giftcard` VALUES ('402', '765303200807', '2318625', '2018-02-06 10:50:47', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('403', '211213057218', '2318625', '2018-02-06 10:50:50', '1', '2018-05-27', '海闻科技有限公司上海分公司', '2018-12-31', 'okou5v1EyVSGhe0QbqfwXLg0KauE', '13564631778', '谢家平', '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('404', '036164404632', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('405', '242644158142', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('406', '757286528205', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('407', '205682116381', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('408', '114803350482', '2318625', '2018-02-06 10:50:50', '1', '2018-04-01', '海闻科技有限公司上海分公司', '2018-12-31', 'okou5v5-x1t8BDoeL8KNxqgPgspU', '13918796463', '刘小雪', '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('409', '302105877703', '2318625', '2018-02-06 10:50:50', '1', '2018-05-16', '海闻科技有限公司上海分公司', '2018-12-31', 'okou5vxVnwr4fkz1ggDX-ba0gud4', '18516582789', '洪七公', '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('410', '036332262263', '2318625', '2018-02-06 10:50:50', '1', '2018-05-27', '海闻科技有限公司上海分公司', '2018-12-31', 'okou5v_gjvwrv5RLyg6-RdNtZ9OI', '18121417137', '川兔', '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('411', '342357863361', '2318625', '2018-02-06 10:50:50', '1', '2018-05-06', '海闻科技有限公司上海分公司', '2018-12-31', 'okou5vxR51rxTY2wM_HgLToZcqq4', '18019788257', '刘朝晖', '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('412', '013144502327', '2318625', '2018-02-06 10:50:50', '1', '2018-04-26', '海闻科技有限公司上海分公司', '2018-12-31', 'okou5v_Bif-gtCeyOyzmaElVlkFo', '18621620661', '卢海青', '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('413', '232158662802', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('414', '846713443536', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('415', '157632118688', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('416', '876613712673', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('417', '125012861112', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('418', '317268300646', '2318625', '2018-02-06 10:50:50', '1', '2018-05-21', '海闻科技有限公司上海分公司', '2018-12-31', 'okou5v-DqGlOWtQr1h5Go2RdjGfU', '15821088323', '崔瑾', '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('419', '877306140067', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('420', '130056364626', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('421', '371610400171', '2318625', '2018-02-06 10:50:50', '0', null, '海闻科技有限公司上海分公司', '2018-12-31', null, null, null, '500', '1', 'https://h5.youzan.com/v2/goods/3eqkrl9wal94y');
INSERT INTO `giftcard` VALUES ('422', '726568457183', '2506851', '2018-05-28 15:15:57', '0', null, null, '2018-05-31 12:59:38', null, null, null, '10.00', '0', null);
INSERT INTO `giftcard` VALUES ('423', '628048115570', '2506851', '2018-05-28 15:15:57', '0', null, null, '2018-05-31 12:59:38', null, null, null, '10.00', '0', null);
INSERT INTO `giftcard` VALUES ('424', '078284813528', '2506851', '2018-05-28 15:15:57', '0', null, null, '2018-05-31 12:59:38', null, null, null, '10.00', '0', null);
INSERT INTO `giftcard` VALUES ('425', '404384548772', '2506851', '2018-05-28 15:15:57', '0', null, null, '2018-05-31 12:59:38', null, null, null, '10.00', '0', null);
INSERT INTO `giftcard` VALUES ('426', '158335016864', '2506851', '2018-05-28 15:15:57', '0', null, null, '2018-05-31 12:59:38', null, null, null, '10.00', '0', null);
INSERT INTO `giftcard` VALUES ('427', '483257123701', '2506851', '2018-05-28 15:15:57', '0', null, null, '2018-05-31 12:59:38', null, null, null, '10.00', '0', null);
INSERT INTO `giftcard` VALUES ('428', '123456789013', '2506851', '2018-05-28 15:15:57', '1', '2018-05-28', null, '2018-05-31 12:59:38', 'okou5vzBVf1Uzcl7MXgKWV0bkTnI', '15221336036', 'YY', '10.00', '1', null);
INSERT INTO `giftcard` VALUES ('429', '123456789012', '2506851', '2018-05-28 15:15:57', '1', '2018-05-28', null, '2018-05-31 12:59:38', 'okou5v0jwgn_KHa85arH08pt5gtI', '15221336036', '沈', '10.00', '1', null);

-- ----------------------------
-- Table structure for t_apps
-- ----------------------------
DROP TABLE IF EXISTS `t_apps`;
CREATE TABLE `t_apps` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `client_id` varchar(50) DEFAULT NULL,
  `client_secret` varchar(200) DEFAULT NULL,
  `kdt_id` varchar(50) DEFAULT NULL,
  `appname` varchar(50) DEFAULT NULL,
  `expireddate` datetime DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  `appcode` varchar(50) DEFAULT NULL,
  `homeurl` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_apps
-- ----------------------------
INSERT INTO `t_apps` VALUES ('4', '2e6259a7d6e91d6875', '7dc62b1091aff300d4bf6153e7e84b84', '40161714', 'mid', '2018-06-28 23:59:59', 'active', '6ecc292cf0344265a2de391c3ae97b5b', null);
INSERT INTO `t_apps` VALUES ('5', '2e6259a7d6e91d6875', '7dc62b1091aff300d4bf6153e7e84b84', '40161714', '蜜岛果园', '2018-08-28 23:59:59', 'active', '6813f5faaabc48db91b7c62f7b5d3903', null);

-- ----------------------------
-- Table structure for t_company
-- ----------------------------
DROP TABLE IF EXISTS `t_company`;
CREATE TABLE `t_company` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `companycode` varchar(50) DEFAULT NULL,
  `companyname` varchar(200) DEFAULT NULL,
  `registerdate` datetime DEFAULT NULL,
  `logo` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_company
-- ----------------------------

-- ----------------------------
-- Table structure for t_user
-- ----------------------------
DROP TABLE IF EXISTS `t_user`;
CREATE TABLE `t_user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `mobile` varchar(50) DEFAULT NULL,
  `registerdate` datetime DEFAULT NULL,
  `companyid` int(11) DEFAULT NULL,
  `CompanyName` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user
-- ----------------------------
INSERT INTO `t_user` VALUES ('1', '15221336036', '301ce2dede237997', '15221336036', '2018-05-28 14:23:00', null, '上海醒信信息科技有限公司');
INSERT INTO `t_user` VALUES ('2', '15221336037', '301ce2dede237997', '15221336037', '2018-05-28 16:48:00', null, '上海醒信信息科技有限公司1');

-- ----------------------------
-- Table structure for t_user2app
-- ----------------------------
DROP TABLE IF EXISTS `t_user2app`;
CREATE TABLE `t_user2app` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `userid` int(11) DEFAULT NULL,
  `appid` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_user2app
-- ----------------------------
INSERT INTO `t_user2app` VALUES ('5', '1', '5');

-- ----------------------------
-- View structure for v_giftcard
-- ----------------------------
DROP VIEW IF EXISTS `v_giftcard`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_giftcard` AS select `giftcard`.`id` AS `id`,`giftcard`.`giftcardcode` AS `giftcardcode`,`giftcard`.`PromoId` AS `PromoId`,`giftcard`.`generatedate` AS `generatedate`,`giftcard`.`isused` AS `isused`,`giftcard`.`useddate` AS `useddate`,`giftcard`.`forcompany` AS `forcompany`,`giftcard`.`expireddate` AS `expireddate`,`giftcard`.`usedopenid` AS `usedopenid`,`giftcard`.`usedmobile` AS `usedmobile`,`giftcard`.`usedname` AS `usedname`,`giftcard`.`amount` AS `amount`,`giftcard`.`enabled` AS `enabled`,`giftcard`.`jumpurl` AS `jumpurl`,(case when (`giftcard`.`isused` = 1) then '已使用' else '未使用' end) AS `isusedt`,(case when (`giftcard`.`enabled` = 1) then '已激活' else '未激活' end) AS `enabledt` from `giftcard`;

-- ----------------------------
-- View structure for v_userapps
-- ----------------------------
DROP VIEW IF EXISTS `v_userapps`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `v_userapps` AS select `ta`.`id` AS `id`,`tu`.`id` AS `userid`,`ta`.`appcode` AS `appcode`,`ta`.`appname` AS `appname`,`ta`.`client_id` AS `client_id`,`ta`.`client_secret` AS `client_secret`,`ta`.`kdt_id` AS `kdt_id`,`ta`.`expireddate` AS `expireddate` from ((`t_user` `tu` join `t_user2app` `tua` on((`tu`.`id` = `tua`.`userid`))) join `t_apps` `ta` on((`tua`.`appid` = `ta`.`id`)));
