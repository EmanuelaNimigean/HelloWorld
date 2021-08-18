using HelloWorldWebMVC.Services;
using HelloWorldWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using HelloWorldWebMVC;

namespace HelloWorldWeb.Test
{
    public class StarttupTests
    {
        [Fact]
        public void ConvertHerokuStringToASPNETString()
        {
            //Assume
            string herokuConnectionString = "postgres://vhcctzdilboktc:425ef55e3d410d9ced84c58ed1358651b551aa219eb4425f62d18e4fcaf979b9@ec2-34-251-245-108.eu-west-1.compute.amazonaws.com:5432/d23t5oj307pe99";

            //Act
            string aspnetConnectionString = Startup.ConvertHerokuStringToASPNETString(herokuConnectionString);

            //Assert
            Assert.Equal("Server=ec2-34-251-245-108.eu-west-1.compute.amazonaws.com;Port=5432;Database=d23t5oj307pe99;SslMode=Require;Trust Server Certificate=true;Integrated Security=true;User Id=vhcctzdilboktc;Password=425ef55e3d410d9ced84c58ed1358651b551aa219eb4425f62d18e4fcaf979b9;", aspnetConnectionString);
        }
    }
}
