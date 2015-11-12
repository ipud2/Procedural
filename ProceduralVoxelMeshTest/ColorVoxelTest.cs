﻿// Copyright 2015 afuzzyllama. All Rights Reserved.
using System;
using NUnit.Framework;
using ProceduralVoxelMesh;
using UnityEngine;
// ReSharper disable NotAccessedVariable
// ReSharper disable JoinDeclarationAndInitializer
// ReSharper disable UseObjectOrCollectionInitializer
// ReSharper disable SuspiciousTypeConversion.Global

namespace ProceduralVoxelMeshTest
{
    [TestFixture]
    public class ColorVoxelTest
    {
        [Test]
        public void CreateTest()
        {
            ColorVoxel colorVoxel;
            colorVoxel = new ColorVoxel();
            Assert.IsTrue(colorVoxel.Empty);

            colorVoxel = new ColorVoxel(Color.black);
            Assert.IsFalse(colorVoxel.Empty);
            Assert.AreEqual(colorVoxel.Color, Color.black);
            Assert.AreEqual(colorVoxel.Metallic, 0.0f);
            Assert.AreEqual(colorVoxel.Smoothness, 0.0f);
            Assert.AreEqual(colorVoxel.Emission, 0.0f);

            colorVoxel = new ColorVoxel(Color.blue, 0.25f, 0.5f, 0.75f);
            Assert.IsFalse(colorVoxel.Empty);
            Assert.AreEqual(colorVoxel.Color, Color.blue);
            Assert.AreEqual(colorVoxel.Metallic, 0.25f);
            Assert.AreEqual(colorVoxel.Smoothness, 0.5f);
            Assert.AreEqual(colorVoxel.Emission, 0.75f);
        }

        [Test]
        public void EmptyPropertyTest()
        {
            var colorVoxel = new ColorVoxel();
            colorVoxel.Empty = true;
            Assert.AreEqual(colorVoxel.Empty, true);

            Assert.Throws<InvalidOperationException>(() => colorVoxel.Empty = false);
        }

        [Test]
        public void ColorPropertyTest()
        {
            ColorVoxel colorVoxel;
            Color color;

            colorVoxel = new ColorVoxel();
            Assert.Throws<InvalidOperationException>(() => color = colorVoxel.Color);

            colorVoxel = new ColorVoxel(Color.black);
            color = colorVoxel.Color;
            Assert.AreEqual(color, Color.black);

            colorVoxel.Color = Color.blue;
            color = colorVoxel.Color;
            Assert.AreEqual(color, Color.blue);
        }

        [Test]
        public void MetallicPropertyTest()
        {
            float metallic;

            var colorVoxel = new ColorVoxel();
            Assert.Throws<InvalidOperationException>(() => metallic = colorVoxel.Metallic);
            Assert.Throws<InvalidOperationException>(() => colorVoxel.Metallic = 1.0f);

            colorVoxel = new ColorVoxel(Color.blue, 0.25f);
            metallic = colorVoxel.Metallic;
            Assert.AreEqual(metallic, 0.25f);

            colorVoxel.Metallic = 0.5f;
            Assert.AreEqual(colorVoxel.Metallic, 0.5f);

            Assert.Throws<InvalidOperationException>(() => colorVoxel.Metallic = -1.0f);
            Assert.Throws<InvalidOperationException>(() => colorVoxel.Metallic = 2.0f);
        }

        [Test]
        public void SmoothnessPropertyTest()
        {
            float smoothness;

            var colorVoxel = new ColorVoxel();
            Assert.Throws<InvalidOperationException>(() => smoothness = colorVoxel.Smoothness);
            Assert.Throws<InvalidOperationException>(() => colorVoxel.Smoothness = 1.0f);

            colorVoxel = new ColorVoxel(Color.blue, 1.0f, 0.25f);
            smoothness = colorVoxel.Smoothness;
            Assert.AreEqual(smoothness, 0.25f);

            colorVoxel.Smoothness = 0.5f;
            Assert.AreEqual(colorVoxel.Smoothness, 0.5f);

            Assert.Throws<InvalidOperationException>(() => colorVoxel.Smoothness = -1.0f);
            Assert.Throws<InvalidOperationException>(() => colorVoxel.Smoothness = 2.0f);
        }

        [Test]
        public void EmissionPropertyTest()
        {
            float emission;

            var colorVoxel = new ColorVoxel();
            Assert.Throws<InvalidOperationException>(() => emission = colorVoxel.Emission);
            Assert.Throws<InvalidOperationException>(() => colorVoxel.Emission = 1.0f);

            colorVoxel = new ColorVoxel(Color.blue, 1.0f, 1.0f, 0.25f);
            emission = colorVoxel.Emission;
            Assert.AreEqual(emission, 0.25f);

            colorVoxel.Emission = 0.5f;
            Assert.AreEqual(colorVoxel.Emission, 0.5f);

            Assert.Throws<InvalidOperationException>(() => colorVoxel.Emission = -1.0f);
            Assert.Throws<InvalidOperationException>(() => colorVoxel.Emission = 2.0f);
        }

        [Test]
        public void EqualsTest()
        {
            var voxelOne = new ColorVoxel();
            var voxelTwo = new ColorVoxel(Color.blue, 1.0f, 1.0f, 1.0f);
            Assert.IsFalse(voxelOne.Equals(voxelTwo));

            voxelOne = new ColorVoxel(Color.blue, 1.0f, 1.0f, 1.0f);
            Assert.IsTrue(voxelOne.Equals(voxelTwo));

            int notVoxel = 1;
            // ReSharper disable once ExpressionIsAlwaysNull
            Assert.IsFalse(voxelOne.Equals(notVoxel));

            var color = Color.black;
            Assert.IsFalse(voxelOne.Equals(color));
        }

        [Test]
        public void GetHashCodeTest()
        {
            var voxelOne = new ColorVoxel();
            var voxelTwo = new ColorVoxel(Color.blue, 1.0f, 1.0f, 1.0f);

            Assert.IsFalse(voxelOne.GetHashCode() == voxelTwo.GetHashCode());

            voxelOne = new ColorVoxel(Color.blue, 1.0f, 1.0f, 1.0f);

            Assert.IsTrue(voxelOne.GetHashCode() == voxelTwo.GetHashCode());
        }
    }
}
