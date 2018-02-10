DELIMITER $$
CREATE DEFINER=`root`@`%` PROCEDURE `allSample_proc`(in Sample_ID int, out Sample_No varchar(50))
BEGIN
select SampleNo into Sample_No from npd_samplegeneralspec_tbl
where SampleID= Sample_ID ;
END$$
DELIMITER ;
