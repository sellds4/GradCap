using GradCap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GradCap.DAL
{
    public class GradCapInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GradCapContext>
    {
        protected override void Seed(GradCapContext context)
        {
            var schools = new List<School>
            {
                new School{Name="University of One",
                            Address="1 One Way",
                            City="One",
                            State=USAStates.CA,
                            Size=10000,
                            SchoolType=SchoolType.Private,
                            Tuition=20000,
                            AdmitRate=80,
                            AvgSAT=1250,
                            AvgACT=26,
                            Website="www.One.com"
                },
                new School{Name="University of Two",
                            Address="1 Two Way",
                            City="Two",
                            State=USAStates.OH,
                            Size=10000,
                            SchoolType=SchoolType.Private,
                            Tuition=20000,
                            AdmitRate=80,
                            AvgSAT=1250,
                            AvgACT=26,
                            Website="www.Two.com"
                },
                new School{Name="University of Three",
                            Address="1 Three Way",
                            City="Three",
                            State=USAStates.ID,
                            Size=10000,
                            SchoolType=SchoolType.Private,
                            Tuition=20000,
                            AdmitRate=80,
                            AvgSAT=1250,
                            AvgACT=26,
                            Website="www.Three.com"
                },
                new School{Name="University of Four",
                            Address="1 Four Way",
                            City="Four",
                            State=USAStates.KY,
                            Size=10000,
                            SchoolType=SchoolType.Private,
                            Tuition=20000,
                            AdmitRate=80,
                            AvgSAT=1250,
                            AvgACT=26,
                            Website="www.Four.com"
                },
                new School{Name="University of Five",
                            Address="1 Five Way",
                            City="Five",
                            State=USAStates.IL,
                            Size=10000,
                            SchoolType=SchoolType.Private,
                            Tuition=20000,
                            AdmitRate=80,
                            AvgSAT=1250,
                            AvgACT=26,
                            Website="www.Five.com"
                },
                new School{Name="University of Six",
                            Address="1 Six Way",
                            City="Six",
                            State=USAStates.WA,
                            Size=10000,
                            SchoolType=SchoolType.Public,
                            Tuition=20000,
                            AdmitRate=80,
                            AvgSAT=1250,
                            AvgACT=26,
                            Website="www.Six.com"
                },
                new School{Name="University of Seven",
                            Address="1 Seven Way",
                            City="Seven",
                            State=USAStates.OR,
                            Size=10000,
                            SchoolType=SchoolType.Public,
                            Tuition=20000,
                            AdmitRate=80,
                            AvgSAT=1250,
                            AvgACT=26,
                            Website="www.Seven.com"
                },
                new School{Name="University of Eight",
                            Address="1 Eight Way",
                            City="Eight",
                            State=USAStates.TX,
                            Size=10000,
                            SchoolType=SchoolType.Public,
                            Tuition=20000,
                            AdmitRate=80,
                            AvgSAT=1250,
                            AvgACT=26,
                            Website="www.Eight.com"
                },
                new School{Name="University of Nine",
                            Address="1 Nine Way",
                            City="Nine",
                            State=USAStates.NY,
                            Size=10000,
                            SchoolType=SchoolType.Public,
                            Tuition=20000,
                            AdmitRate=80,
                            AvgSAT=1250,
                            AvgACT=26,
                            Website="www.Nine.com"
                },
                new School{Name="University of Ten",
                            Address="1 Ten Way",
                            City="Ten",
                            State=USAStates.NE,
                            Size=10000,
                            SchoolType=SchoolType.Public,
                            Tuition=20000,
                            AdmitRate=80,
                            AvgSAT=1250,
                            AvgACT=26,
                            Website="www.Ten.com"
                }
            };

            schools.ForEach(s => context.Schools.Add(s));
            context.SaveChanges();
        }
    }
}