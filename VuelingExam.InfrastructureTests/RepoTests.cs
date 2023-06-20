using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using VuelingExam.Infrastructure;
using System;
using System.IO;
using VuelingExam.Transversal.Models;
using System.Text.Json;
using System.Collections.Generic;

[TestClass]
public class RepoTests
{
    private IContainer _container;
    private Mock<IFileWrapper> _mockFileWrapper;

    [TestInitialize]
    public void TestInitialize()
    {
        _mockFileWrapper = new Mock<IFileWrapper>();

        var builder = new ContainerBuilder();
        builder.RegisterInstance(_mockFileWrapper.Object).As<IFileWrapper>();
        builder.RegisterType<Repo>().As<IRepo>();
        _container = builder.Build();
    }

    [DataTestMethod]
    [DataRow("testName1", "testSurname1", new int[] { 1, 2, 3 })]
    [DataRow("testName2", "testSurname2", new int[] { 4, 5, 6 })]
    [DataRow("testName3", "testSurname3", new int[] { 7, 8, 9 })]

    [DataRow(null, "testSurname4", new int[] { 10, 11, 12 })]
    [DataRow("testName5", null, new int[] { 13, 14, 15 })]
    [DataRow("testName6", "testSurname6", null)]
    [DataRow(null, null, null)]
    public void TestWriteData(string name, string surname, int[] values)
    {
        // Arrange
        var studentToWrite = new StudentDto(name, surname, values);
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "output.txt");
        var existingStudents = new List<StudentDto> { new StudentDto("existingName", "existingSurname", new int[] { 7, 8, 9 }) };
        string existingStudentsJson = JsonSerializer.Serialize(existingStudents);

        _mockFileWrapper.Setup(f => f.Exists(path)).Returns(true);
        _mockFileWrapper.Setup(f => f.ReadAllText(path)).Returns(existingStudentsJson);

        // Act
        var repo = _container.Resolve<IRepo>();

        if (studentToWrite == null || name == null || surname == null || values == null)
        {
            Assert.ThrowsException<ArgumentNullException>(() => repo.WriteData(studentToWrite));
        }
        else
        {
            string result = repo.WriteData(studentToWrite);

            // Assert
            existingStudents.Add(studentToWrite);
            string expectedJson = JsonSerializer.Serialize(existingStudents);
            _mockFileWrapper.Verify(f => f.WriteAllText(path, expectedJson), Times.Once);
            Assert.AreEqual("Ok!", result);
        }
    }


    [TestMethod]
    public void TestReadData()
    {
        // Arrange
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "output.txt");
        var students = new List<StudentDto> { new StudentDto("testName", "testSurname", new int[] { 1, 2, 3 }) };
        string studentsJson = JsonSerializer.Serialize(students);
        _mockFileWrapper.Setup(f => f.ReadAllText(path)).Returns(studentsJson);

        // Act
        var repo = _container.Resolve<IRepo>();
        var result = repo.ReadData();

        // Assert
        Assert.AreEqual(students.Count, result.Count);
        for (int i = 0; i < students.Count; i++)
        {
            Assert.AreEqual(students[i].Name, result[i].Name);
            Assert.AreEqual(students[i].Surname, result[i].Surname);
            CollectionAssert.AreEqual(students[i].Values, result[i].Values);
        }
    }
}
