﻿using FluentAssertions;
using Qt.NetCore.Qml;
using Qt.NetCore.Types;
using Xunit;

namespace Qt.NetCore.Tests
{
    public class NetVariantTests : BaseTests
    {
        public class TestObject
        {
            
        }
        
        [Fact]
        public void Variant_is_invalid_by_default()
        {
            var variant = new NetVariant();
            variant.VariantType.Should().Be(NetVariantType.Invalid);
        }
        
        [Fact]
        public void Can_store_net_instance()
        {
            var testObject = new TestObject();
            var variant = new NetVariant();
            variant.Instance.Should().BeNull();
            variant.Instance = NetInstance.CreateFromObject(testObject);
            variant.Instance.Should().NotBeNull();
            variant.Instance.Instance.Should().Be(testObject);
            variant.VariantType.Should().Be(NetVariantType.Object);
        }
    }
}