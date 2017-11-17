namespace Lost.Math.Int2D
{
    using System;
    using Xunit;
    using static Lost.Math.Int2D.Direction;

    public class DirectionTests
    {
        [Fact]
        public void CorrectVectors()
        {
            Assert.Equal(new Vector(x: 1, y: 0), Right.Vector);
            Assert.Equal(new Vector(x: 0, y: 1), Down.Vector);
            Assert.Equal(new Vector(x: -1, y: 0), Left.Vector);
            Assert.Equal(new Vector(x: 0, y: -1), Up.Vector);
        }
    }
}
