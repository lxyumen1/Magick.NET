﻿// Copyright 2013-2020 Dirk Lemstra <https://github.com/dlemstra/Magick.NET/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in
// compliance with the License. You may obtain a copy of the License at
//
//   https://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.

using System;
using ImageMagick;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Magick.NET.Tests
{
    public partial class MagickImageTests
    {
        [TestClass]
        public class TheSetAttributeMethod
        {
            [TestClass]
            public class WithBoolean
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenNameIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        ExceptionAssert.Throws<ArgumentNullException>("name", () =>
                        {
                            image.SetAttribute(null, true);
                        });
                    }
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenNameIsEmpty()
                {
                    using (var image = new MagickImage())
                    {
                        ExceptionAssert.Throws<ArgumentException>("name", () =>
                        {
                            image.SetAttribute(string.Empty, true);
                        });
                    }
                }

                [TestMethod]
                public void ShouldSetValue()
                {
                    using (var image = new MagickImage())
                    {
                        image.SetAttribute("test", true);
                        Assert.AreEqual("true", image.GetAttribute("test"));
                    }
                }
            }

            [TestClass]
            public class WithString
            {
                [TestMethod]
                public void ShouldThrowExceptionWhenNameIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        ExceptionAssert.Throws<ArgumentNullException>("name", () =>
                        {
                            image.SetAttribute(null, "foo");
                        });
                    }
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenNameIsEmpty()
                {
                    using (var image = new MagickImage())
                    {
                        ExceptionAssert.Throws<ArgumentException>("name", () =>
                        {
                            image.SetAttribute(string.Empty, "foo");
                        });
                    }
                }

                [TestMethod]
                public void ShouldThrowExceptionWhenValueIsNull()
                {
                    using (var image = new MagickImage())
                    {
                        ExceptionAssert.Throws<ArgumentNullException>("value", () =>
                        {
                            image.SetAttribute("foo", null);
                        });
                    }
                }

                [TestMethod]
                public void ShouldSetEmptyValue()
                {
                    using (var image = new MagickImage())
                    {
                        image.SetAttribute("test", string.Empty);
                        Assert.AreEqual(string.Empty, image.GetAttribute("test"));
                    }
                }

                [TestMethod]
                public void ShouldSetValue()
                {
                    using (var image = new MagickImage())
                    {
                        image.SetAttribute("test", "123");
                        Assert.AreEqual("123", image.GetAttribute("test"));

                        image.SetArtifact("foo", "bar");
                    }
                }
            }
        }
    }
}
