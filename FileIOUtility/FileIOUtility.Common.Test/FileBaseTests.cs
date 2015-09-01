using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileIOUtility.Common;
using System.IO;

namespace FileIOUtility.Common.Test
{
    [TestClass]
    public class FileBaseTests
    {
        private static string TestDataDir;

        private static string One_Liner_Text_File;

        private static string One_Liner_Text_File_Copy;

        private static string Multi_Line_Text_File;

        private static string Multi_Line_Text_File_Copy;

        private static string Empty_Text_File;

        private static string Empty_Text_File_Copy;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            //Set environment variables once before doing any tests
            TestDataDir = @"..\..\TestData";
            One_Liner_Text_File = TestDataDir + @"\One_Liner.txt";
            One_Liner_Text_File_Copy = One_Liner_Text_File + ".copy";
            Multi_Line_Text_File = TestDataDir + @"\Multi_Liner.txt";
            Multi_Line_Text_File_Copy = Multi_Line_Text_File + ".copy";
            Empty_Text_File = TestDataDir + @"\Empty_File.txt";
            Empty_Text_File_Copy = Empty_Text_File + ".copy";
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //Reset environment before every test
            using (StreamWriter sw = new StreamWriter(One_Liner_Text_File, append: false))
            {
                sw.Write("This is a one line text file");
            }

            File.Delete(One_Liner_Text_File_Copy);

            using (StreamWriter sw = new StreamWriter(Multi_Line_Text_File, append: false))
            {
                sw.WriteLine("Line 1 - a horse is a horse, of course, of course...");
                sw.WriteLine("Line 2 - it was the best of times, it was the worst of time, it was the age of wisdom, it was the age of foolishness...");
                sw.WriteLine("Line 3 - april is the cruellest month");
            }

            File.Delete(Multi_Line_Text_File_Copy);

            using (StreamWriter sw = new StreamWriter(Empty_Text_File, append: false))
            {
            }

            File.Delete(Empty_Text_File_Copy);
        }

        [TestMethod]
        public void Instance()
        {
            //Probably don't need to test this, but make sure the Instance is not null
            Assert.IsNotNull(FileBase.Instance);
        }

        [TestMethod]
        public void Exists()
        {
            //Make sure test initialize worked properly
            Assert.IsTrue(File.Exists(One_Liner_Text_File), "Test environment not set up properly");

            //Test for existing file
            Assert.IsTrue(FileBase.Instance.Exists(One_Liner_Text_File));

            //Delete the file and assert that it no longer exists
            File.Delete(One_Liner_Text_File);
            Assert.IsFalse(FileBase.Instance.Exists(One_Liner_Text_File));
        }

        [TestMethod]
        public void Delete()
        {
            //Make sure test initialize worked properly
            Assert.IsTrue(File.Exists(One_Liner_Text_File), "Test environment not set up properly");

            //Delete the file
            FileBase.Instance.Delete(One_Liner_Text_File);

            //Assert that it no longer exists
            Assert.IsFalse(File.Exists(One_Liner_Text_File));
        }

        [TestMethod]
        public void Rename()
        {
            //Make sure test initialize worked properly
            Assert.IsTrue(File.Exists(One_Liner_Text_File), "Test environment not set up properly");
            Assert.IsFalse(File.Exists(One_Liner_Text_File_Copy), "Test environment not set up properly");

            //Rename the file
            FileBase.Instance.Rename(One_Liner_Text_File, One_Liner_Text_File_Copy);

            //Check that old file is gone and new file is present
            Assert.IsFalse(File.Exists(One_Liner_Text_File));
            Assert.IsTrue(File.Exists(One_Liner_Text_File_Copy));
        }

        [TestMethod]
        public void CopyOverwrite_DestinationFileExists()
        {
            //Make sure test initialize worked properly
            Assert.IsTrue(File.Exists(One_Liner_Text_File), "Test environment not set up properly");
            Assert.IsTrue(File.Exists(Multi_Line_Text_File), "Test environment not set up properly");

            //Copy file to two locations, one that exists one that does not
            FileBase.Instance.CopyOverwrite(One_Liner_Text_File, Multi_Line_Text_File);
            Assert.IsTrue(File.Exists(One_Liner_Text_File));
            Assert.IsTrue(File.Exists(Multi_Line_Text_File));

            //Check content of files to make sure they match since destination file was overwritten
            Assert.AreEqual(readTextFileToEnd(One_Liner_Text_File), readTextFileToEnd(Multi_Line_Text_File));
        }

        [TestMethod]
        public void CopyOverwrite_DestinationFileDoesNotExist()
        {
            //Make sure test initialize worked properly
            Assert.IsTrue(File.Exists(One_Liner_Text_File), "Test environment not set up properly");
            Assert.IsFalse(File.Exists(One_Liner_Text_File_Copy), "Test environment not set up properly");

            //Copy file to two locations, one that exists one that does not
            FileBase.Instance.CopyOverwrite(One_Liner_Text_File, One_Liner_Text_File_Copy);
            Assert.IsTrue(File.Exists(One_Liner_Text_File));
            Assert.IsTrue(File.Exists(One_Liner_Text_File_Copy));

            //Check content of files to make sure they match
            Assert.AreEqual(readTextFileToEnd(One_Liner_Text_File), readTextFileToEnd(One_Liner_Text_File_Copy));
        }

        [TestMethod]
        public void CopyNoOverwrite_DestinationFileExists()
        {
            //Make sure test initialize worked properly
            Assert.IsTrue(File.Exists(One_Liner_Text_File), "Test environment not set up properly");
            Assert.IsTrue(File.Exists(Multi_Line_Text_File), "Test environment not set up properly");

            //Try copying one file over the other, with no overwrite, it should not copy
            FileBase.Instance.CopyNoOverwrite(One_Liner_Text_File, Multi_Line_Text_File);
            Assert.IsTrue(File.Exists(One_Liner_Text_File));
            Assert.IsTrue(File.Exists(Multi_Line_Text_File));

            //Check content of files to make sure they do not match
            Assert.AreNotEqual(readTextFileToEnd(One_Liner_Text_File), readTextFileToEnd(Multi_Line_Text_File));
        }

        [TestMethod]
        public void CopyNoOverwrite_DestinationFileDoesNotExist()
        {
            //Make sure test initialize worked properly
            Assert.IsTrue(File.Exists(One_Liner_Text_File), "Test environment not set up properly");
            Assert.IsFalse(File.Exists(One_Liner_Text_File_Copy), "Test environment not set up properly");

            //Try copying one file over the other, with no overwrite, it should copy since destination does not exist
            FileBase.Instance.CopyNoOverwrite(One_Liner_Text_File, One_Liner_Text_File_Copy);
            Assert.IsTrue(File.Exists(One_Liner_Text_File));
            Assert.IsTrue(File.Exists(One_Liner_Text_File_Copy));

            //Check content of files to make sure they do not match
            Assert.AreEqual(readTextFileToEnd(One_Liner_Text_File), readTextFileToEnd(One_Liner_Text_File_Copy));
        }

        [TestMethod]
        public void Copy_OkToOverwrite_DestinationFileExists()
        {
            //Make sure test initialize worked properly
            Assert.IsTrue(File.Exists(One_Liner_Text_File), "Test environment not set up properly");
            Assert.IsTrue(File.Exists(Multi_Line_Text_File), "Test environment not set up properly");

            //Try copying one file over the other, should overwrite
            FileBase.Instance.CopyOverwrite(One_Liner_Text_File, Multi_Line_Text_File);
            Assert.IsTrue(File.Exists(One_Liner_Text_File));
            Assert.IsTrue(File.Exists(Multi_Line_Text_File));

            //Check content of files to make sure they match since overwrite was enabled
            Assert.AreEqual(readTextFileToEnd(One_Liner_Text_File), readTextFileToEnd(Multi_Line_Text_File));
        }

        [TestMethod]
        public void Copy_NotOkToOverwrite_DestinationFileExists()
        {
            //Make sure test initialize worked properly
            Assert.IsTrue(File.Exists(One_Liner_Text_File), "Test environment not set up properly");
            Assert.IsTrue(File.Exists(Multi_Line_Text_File), "Test environment not set up properly");

            //Try copying one file over the other, with no overwrite, it should not copy
            FileBase.Instance.CopyNoOverwrite(One_Liner_Text_File, Multi_Line_Text_File);
            Assert.IsTrue(File.Exists(One_Liner_Text_File));
            Assert.IsTrue(File.Exists(Multi_Line_Text_File));

            //Check content of files to make sure they do not match
            Assert.AreNotEqual(readTextFileToEnd(One_Liner_Text_File), readTextFileToEnd(Multi_Line_Text_File));
        }

        [TestMethod]
        public void Copy_OkToOverwrite_DestinationFileDoesNotExist()
        {
            //Make sure test initialize worked properly
            Assert.IsTrue(File.Exists(One_Liner_Text_File), "Test environment not set up properly");
            Assert.IsFalse(File.Exists(One_Liner_Text_File_Copy), "Test environment not set up properly");

            //Try copying one file over the other, should overwrite since destination doesn't exist
            FileBase.Instance.CopyOverwrite(One_Liner_Text_File, One_Liner_Text_File_Copy);
            Assert.IsTrue(File.Exists(One_Liner_Text_File));
            Assert.IsTrue(File.Exists(One_Liner_Text_File_Copy));

            //Check content of files to make sure they match since overwrite was enabled
            Assert.AreEqual(readTextFileToEnd(One_Liner_Text_File), readTextFileToEnd(One_Liner_Text_File_Copy));
        }

        [TestMethod]
        public void Copy_NotOkToOverwrite_DestinationFileDoesNotExist()
        {
            //Make sure test initialize worked properly
            Assert.IsTrue(File.Exists(One_Liner_Text_File), "Test environment not set up properly");
            Assert.IsFalse(File.Exists(One_Liner_Text_File_Copy), "Test environment not set up properly");

            //Try copying one file over the other, with no overwrite, it should copy since destination file doesn't exist
            FileBase.Instance.CopyNoOverwrite(One_Liner_Text_File, One_Liner_Text_File_Copy);
            Assert.IsTrue(File.Exists(One_Liner_Text_File));
            Assert.IsTrue(File.Exists(One_Liner_Text_File_Copy));

            //Check content of files to make sure they do not match
            Assert.AreEqual(readTextFileToEnd(One_Liner_Text_File), readTextFileToEnd(One_Liner_Text_File_Copy));
        }

        private string readTextFileToEnd(string filename)
        {
            //Convenience method to read whole file into a string
            using (StreamReader r = new StreamReader(filename))
            {
                return r.ReadToEnd();
            }
        }
    }
}
