START TRANSACTION
;
ALTER TABLE `vehicle`
  ADD COLUMN `elaboration` VARCHAR(510)
;
COMMIT