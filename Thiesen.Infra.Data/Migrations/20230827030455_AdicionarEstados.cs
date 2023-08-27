using Microsoft.EntityFrameworkCore.Migrations;
using Thiesen.Infra.Data.Seed;

#nullable disable

namespace Thiesen.Infra.Data.Migrations
{
    public partial class AdicionarEstados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            AdicionarEstadosSeed.Seed(migrationBuilder);
        }
    }
}
