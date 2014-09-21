Fox One POS

Change History
04/07/2014	0.1b	Initial beta release

04/08/2014	0.1.1b	Bug fixes:
					- Bug 7: Import from OpenCart had special discount level reversed.
					- Bug 8: Price of an item was not calculating correctly.  The "Special discount rate level" field was being applied after rounding, instead of before.
					- Bug 9: Price of an item did not correctly round up to nearest quarter.  Price should have rounded to $5.50, but instead rounded to 5.25.  unrounded price was 5.42.  Problem was that sales tax wasn't included when it should have been.
					- Task 10: Added "+" on quantity change CSV import to OpenCart file if change is positive.
					- Bug 11: If running on Windows Surface 8.1, Starting cash, tax rate, and "close day" were all inaccessible.  Moved zOrder to put status area on top of tab control in the hopes of fixing.

					Other changes:
					- Renamed assembly from SmallBusinessManager.exe to FoxOnePOS.exe
					- Added export configuration and log file function
					- Added rudimentary logging and severe exception handling.

04/10/2014	0.2b	New features added:
					- Task 13: Completed "Receive Inventory" functionality.
					- Added direct integration to website to update quantity changes.
					- Task 14: Added sorting on columns in Active Inventory listing.
					- Task 15: Added filtering on columns in Active Inventory Listing.
					- Task 19: Built Installer

04/13/2014	0.2.1b	Bug Fix:
					- Quantity did not update when Point of Sale or Receive Inventory posted.
					
					Other:
					Added code to update product ID on export if product ID is zero.
					Task 21: Added update check

05/01/2014	0.2.2b	Changes:
					- Task 23: Changed to have Pricing Model from a new "Selling Price" field.


Outstanding issues:
Close Day report does not seem to report correct figures.
Task 12: Add sales activity on close day report
Task 16: Add complete Active Inventory Maintenance with full import/export to website
Task 17: Add Refund capability
Task 18: Add any needed reporting
Task 20: Add full backup of data and configuration with restoration.
Task 22: Add thorough logging
Task 23: Base Pricing model from new "Selling Price" field.

(path to update data: E:\Users\Russ\Dropbox\Public\FoxOnePOSShared)