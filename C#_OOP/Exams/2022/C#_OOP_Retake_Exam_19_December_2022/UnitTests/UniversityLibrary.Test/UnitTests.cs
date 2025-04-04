namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        [Test]
        public void Constructor_InitializesCorrectly()
        {
            // Act
            UniversityLibrary universityLibrary = new UniversityLibrary();

            // Assert
            Assert.That(universityLibrary, Is.Not.Null);
            Assert.That(universityLibrary.Catalogue, Is.Not.Null);
            Assert.That(universityLibrary.Catalogue, Is.Empty);
        }

        [Test]
        public void AddTextBookToLibrary_Success()
        {
            // Arrange
            TextBook textBook = new TextBook("Title", "Author", "Category");
            UniversityLibrary universityLibrary = new UniversityLibrary();

            // Act
            string result = universityLibrary.AddTextBookToLibrary(textBook);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {textBook.Title} - {textBook.InventoryNumber}");
            sb.AppendLine($"Category: {textBook.Category}");
            sb.AppendLine($"Author: {textBook.Author}");

            string expectedResult = sb.ToString().TrimEnd();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(expectedResult));
                Assert.That(textBook.InventoryNumber, Is.EqualTo(1));
                Assert.That(universityLibrary.Catalogue.Contains(textBook));
            });
        }

        [Test]
        public void AddTextBookToLibrary_ManyBooks()
        {
            // Arrange
            UniversityLibrary universityLibrary = new UniversityLibrary();

            // Act
            string latestResult = string.Empty;
            TextBook latestTextBook = new TextBook("", "", "");
            for (int i = 0; i < 100; i++)
            {
                TextBook textBook = new TextBook($"Title{i}", $"Author{i}", $"Category{i}");
                latestResult = universityLibrary.AddTextBookToLibrary(textBook);
                latestTextBook = textBook;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: {latestTextBook.Title} - {latestTextBook.InventoryNumber}");
            sb.AppendLine($"Category: {latestTextBook.Category}");
            sb.AppendLine($"Author: {latestTextBook.Author}");

            string expectedResult = sb.ToString().TrimEnd();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(latestResult, Is.EqualTo(expectedResult));
                Assert.That(latestTextBook.InventoryNumber, Is.EqualTo(100));
                Assert.That(universityLibrary.Catalogue.Contains(latestTextBook));
            });
        }

        [Test]
        public void LoanTextBook_Success()
        {
            // Arrange
            TextBook textBook = new TextBook("Title", "Author", "Category");
            UniversityLibrary universityLibrary = new UniversityLibrary();
            universityLibrary.AddTextBookToLibrary(textBook);
            string studentName = "StudentName";

            // Act
            string result = universityLibrary.LoanTextBook(textBook.InventoryNumber, studentName);
            string expectedResult = $"{textBook.Title} loaned to {studentName}.";

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(textBook.Holder, Is.EqualTo(studentName));
                Assert.That(result, Is.EqualTo(expectedResult));
            });
        }

        [Test]
        public void LoanTextBook_SecondStudent()
        {
            // Arrange
            TextBook textBook = new TextBook("Title", "Author", "Category");
            UniversityLibrary universityLibrary = new UniversityLibrary();
            universityLibrary.AddTextBookToLibrary(textBook);
            string studentName = "StudentName";
            universityLibrary.LoanTextBook(textBook.InventoryNumber, studentName);

            // Act
            string secondStudentName = "SecondStudentName";
            string result = universityLibrary.LoanTextBook(textBook.InventoryNumber, secondStudentName);
            string expectedResult = $"{textBook.Title} loaned to {secondStudentName}.";

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(textBook.Holder, Is.EqualTo(secondStudentName));
                Assert.That(result, Is.EqualTo(expectedResult));
            });
        }

        [Test]
        public void LoanTextBook_NotReturned()
        {
            // Arrange
            TextBook textBook = new TextBook("Title", "Author", "Category");
            UniversityLibrary universityLibrary = new UniversityLibrary();
            universityLibrary.AddTextBookToLibrary(textBook);
            string studentName = "StudentName";
            universityLibrary.LoanTextBook(textBook.InventoryNumber, studentName);

            // Act
            string result = universityLibrary.LoanTextBook(textBook.InventoryNumber, studentName);
            string expectedResult = $"{studentName} still hasn't returned {textBook.Title}!";

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(textBook.Holder, Is.EqualTo(studentName));
                Assert.That(result, Is.EqualTo(expectedResult));
            });
        }

        [Test]
        public void ReturnTextBook_Success()
        {
            // Arrange
            TextBook textBook = new TextBook("Title", "Author", "Category");
            UniversityLibrary universityLibrary = new UniversityLibrary();
            universityLibrary.AddTextBookToLibrary(textBook);
            string studentName = "StudentName";
            universityLibrary.LoanTextBook(textBook.InventoryNumber, studentName);

            // Act
            string result = universityLibrary.ReturnTextBook(textBook.InventoryNumber);
            string expectedResult = $"{textBook.Title} is returned to the library.";

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(textBook.Holder, Is.Empty);
                Assert.That(result, Is.EqualTo(expectedResult));
            });
        }
    }
}