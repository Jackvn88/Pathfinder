using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pathfinder.Models;

namespace PathfinderTests.Models
{
    [TestClass]
    public class GraphTest
    {
        private Graph _graph;

        [TestInitialize]
        public void SetUp()
        {
            _graph = new Graph();
        }

        
        [TestMethod]
        public void FindAllPaths_FromOneToFour_ReturnCorrectData()
        {
            //Arrange
            var graphRepresentationList = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 5),
                new Tuple<int, int>(4, 6)
            };

            //DataRow not supporting list, so I hardcoded expected for simplicity 
            List<int> expected1 = new List<int> {1, 2, 4};
            List<int> expected2 = new List<int> { 1, 3, 4 };

            //Act
            var result = _graph.FindAllPaths(1, 4, graphRepresentationList);

            var actual1 = result.FirstOrDefault(x => x.SequenceEqual(expected1));
            var actual2 = result.FirstOrDefault(x => x.SequenceEqual(expected2));


            //Assert
            CollectionAssert.AreEqual(expected1, actual1);
            CollectionAssert.AreEqual(expected2, actual2);
        }

        [TestMethod]
        public void FindAllPaths_FromTwoToFour_ReturnCorrectData()
        {
            //Arrange
            var graphRepresentationList = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 5),
                new Tuple<int, int>(4, 6)
            };

            List<int> expected = new List<int> {2, 4};

            //Act
            var result = _graph.FindAllPaths(2, 4, graphRepresentationList);

            var actual = result.FirstOrDefault(x => x.SequenceEqual(expected));

            //Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FindAllPaths_HaveLoop_ReturnCorrectData()
        {
            //Arrange
            var graphRepresentationList = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 5),
                new Tuple<int, int>(4, 6)
            };

            List<int> expected1 = new List<int> { 1, 3, 1, 2, 4, 6};
            List<int> expected2 = new List<int> { 1, 2, 4, 6};
            List<int> expected3 = new List<int> { 1, 3, 4, 6};

            //Act
            var result = _graph.FindAllPaths(1, 6, graphRepresentationList);

            var actual1 = result.FirstOrDefault(x => x.SequenceEqual(expected1));
            var actual2 = result.FirstOrDefault(x => x.SequenceEqual(expected2));
            var actual3 = result.FirstOrDefault(x => x.SequenceEqual(expected3));

            //Assert
            CollectionAssert.AreEqual(expected1, actual1);
            CollectionAssert.AreEqual(expected2, actual2);
            CollectionAssert.AreEqual(expected3, actual3);
        }


        [TestMethod]
        public void FindAllPaths_StartNodeNotExistingNode_ReturnEmptyList()
        {
            //Arrange
            var graphRepresentationList = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 5),
                new Tuple<int, int>(4, 6)
            };

            //Act
            var result = _graph.FindAllPaths(0, 6, graphRepresentationList);

            //Assert
            Assert.IsFalse(result.Any());
            
        }


        [TestMethod]
        public void FindAllPaths_EndNodeNotExistingNode_ReturnEmptyList()
        {
            //Arrange
            var graphRepresentationList = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 5),
                new Tuple<int, int>(4, 6)
            };

            //Act
            var result = _graph.FindAllPaths(1, 0, graphRepresentationList);

            //Assert
            Assert.IsFalse(result.Any());

        }


        [TestMethod]
        public void FindAllPaths_GraphIsNull_ReturnEmptyList()
        {
            //Arrange
            var graphRepresentationList = new List<Tuple<int, int>>
            {
                new Tuple<int, int>(1, 2),
                new Tuple<int, int>(1, 3),
                new Tuple<int, int>(3, 1),
                new Tuple<int, int>(2, 4),
                new Tuple<int, int>(3, 4),
                new Tuple<int, int>(4, 5),
                new Tuple<int, int>(4, 6)
            };

            //Act
            var result = _graph.FindAllPaths(1, 0, null);

            //Assert
            Assert.IsFalse(result.Any());

        }
    }
}
