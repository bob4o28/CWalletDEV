
ALTER TABLE `cwallet`.`MoneyHolders`
ADD COLUMN `Sum` DOUBLE GENERATED ALWAYS AS (Cash + Bank + DebitCard + CreditCard + Savings + Crypto) STORED;
