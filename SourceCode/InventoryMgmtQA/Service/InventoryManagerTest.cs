using InventoryMgmt.Model;
using InventoryMgmt.Service;
using InventoryMgmt.Interface;
using System.ComponentModel.DataAnnotations;
using System.Text;

// guide: https://www.aligrant.com/web/blog/2020-07-20_capturing_console_outputs_with_microsoft_test_framework

namespace InventoryMgmtQA.Service
{
    [TestClass]
    public class InventoryManagerTest
    {
        private IInventoryManager _inventoryManager = new InventoryManager();

        [TestMethod]
        public void TestAddProduct()
        {
            using (StringWriter sw = new StringWriter())
            {
                // capture console output
                Console.SetOut(sw);

                // create a new product with valid attribute values
                _inventoryManager.AddNewProduct(
                    "TestProduct",
                    1,
                    1.23M
                );

                // console output should contain 'success'
                Assert.IsTrue(sw.ToString().Contains("success"));
            }
        }

        [TestMethod]
        public void TestAddProductPriceNegative()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.AddNewProduct(
                    "TestProduct",
                    1,
                    -1.0M
                );
                Assert.IsFalse(sw.ToString().Contains("success"));
            }
        }

        [TestMethod]
        public void TestGetTotalValue()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _inventoryManager.AddNewProduct(
                    "TestProduct",
                    1,
                    2.56M
                );
                _inventoryManager.GetTotalValue();
                Assert.IsTrue(sw.ToString().Contains("2.56"));
            }
        }
    }
}