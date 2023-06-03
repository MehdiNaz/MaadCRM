using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName", "CountryStatusType", "DateCreated", "DateLastUpdate", "DisplayOrder", "IsDefault", "Version" },
                values: new object[] { "01GZTM8DSTQH037TNTFSK9RX9W", "Iran", 1, new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7630), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7630), 1L, true, 0L });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "DateCreated", "DateLastUpdate", "DisplayOrder", "IdCountry", "IsDefault", "ProvinceName", "ProvinceStatusType", "Version" },
                values: new object[,]
                {
                    { "01GZTMF256K84ZGQFMWRB6VTV9", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8050), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8050), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "فارس", 1, 0L },
                    { "01GZTT98N8S8TE5J1WE205Q4WV", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7930), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7940), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "تهران", 1, 0L },
                    { "01H1K9D1EM0ETHJXSCSCVAA279", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8210), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8210), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "همدان", 1, 0L },
                    { "01H1K9D1EM2HNY8V6FMBJ8KNGJ", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7970), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7970), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "خراسان رضوي", 1, 0L },
                    { "01H1K9D1EM3V9V0YQ24VWQH3NW", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8020), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8020), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "زنجان", 1, 0L },
                    { "01H1K9D1EM4B4CX6C4NNEM7758", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8150), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8150), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "گيلان", 1, 0L },
                    { "01H1K9D1EM4G2AZKW55G0XXY4K", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7950), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7950), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "چهارمحال بختياري", 1, 0L },
                    { "01H1K9D1EM4VCR6P076HZP9NE0", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8030), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8030), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "سمنان", 1, 0L },
                    { "01H1K9D1EM5F4CA14SHBQY5A3M", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7900), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7900), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "ايلام", 1, 0L },
                    { "01H1K9D1EM5RX3H602KTN8B645", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8060), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8070), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "قزوين", 1, 0L },
                    { "01H1K9D1EM6F55N6Y6KGWFN9T6", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8080), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8080), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "قم", 1, 0L },
                    { "01H1K9D1EM90RG4C1EEWTMV7T7", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8040), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8040), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "سيستان و بلوچستان", 1, 0L },
                    { "01H1K9D1EMAQX3TWKE4E2QYF7D", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8220), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8220), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "يزد", 1, 0L },
                    { "01H1K9D1EMB12ERVXGDF2H1CTN", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8100), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8100), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "كرمان", 1, 0L },
                    { "01H1K9D1EMB464J1AXYQD5M1S3", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8140), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8140), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "گلستان", 1, 0L },
                    { "01H1K9D1EMFQEMR64YSEWW97KQ", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8110), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8110), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "كرمانشاه", 1, 0L },
                    { "01H1K9D1EMGDCWYDZEWS9JEM7S", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7880), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7880), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "اصفهان", 1, 0L },
                    { "01H1K9D1EMJ26V58SN60PVHVKB", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8090), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8090), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "كردستان", 1, 0L },
                    { "01H1K9D1EMKH817CEGRZM1C1CZ", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7870), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7870), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "اردبيل", 1, 0L },
                    { "01H1K9D1EMMCQ9RVJ3ND78RXGZ", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8170), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8170), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "مازندران", 1, 0L },
                    { "01H1K9D1EMN9WZRNTXJA9B2KCK", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7910), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7910), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "بوشهر", 1, 0L },
                    { "01H1K9D1EMNJDGMT1C8XZBKDFA", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7850), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7850), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "آذربايجان غربي", 1, 0L },
                    { "01H1K9D1EMPTXCDES80PH5VK17", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8130), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8130), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "كهكيلويه و بويراحمد", 1, 0L },
                    { "01H1K9D1EMT7FWNBAEJXNMMR5J", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7980), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7980), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "خراسان شمالي", 1, 0L },
                    { "01H1K9D1EMVCW72SFKRW8EX78W", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8000), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8000), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "خوزستان", 1, 0L },
                    { "01H1K9D1EMVFQ9N0RPTG9ZM5FW", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8190), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8190), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "مركزي", 1, 0L },
                    { "01H1K9D1EMVN4RWA5CB93GNMBA", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8160), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8160), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "لرستان", 1, 0L },
                    { "01H1K9D1EMWANWYD74B58CS011", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7920), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7920), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "البرز", 1, 0L },
                    { "01H1K9D1EMXJS0W9WM8J4NNWQH", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7960), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(7960), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "خراسان جنوبي", 1, 0L },
                    { "01H1K9D1EMXWHRAJGAH13Q7S2A", new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8200), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8200), 1L, "01GZTM8DSTQH037TNTFSK9RX9W", true, "هرمزگان", 1, 0L }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CityStatusType", "DateCreated", "DateLastUpdate", "DisplayOrder", "IdProvince", "IsDefault" },
                values: new object[,]
                {
                    { "01H1K9D1EMCMZE7BKDS4XAYMKD", "قدس", 1, new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8300), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8300), 1L, "01GZTT98N8S8TE5J1WE205Q4WV", true },
                    { "01H1K9D1EMF9WSH7JE0S7CG4BX", "لار", 1, new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8260), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8260), 1L, "01GZTMF256K84ZGQFMWRB6VTV9", true },
                    { "01H1K9D1EMGC8PQTA1CETMW6ZM", "شهریار", 1, new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8280), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8280), 1L, "01GZTT98N8S8TE5J1WE205Q4WV", true },
                    { "01H1K9D1EMHTK7WHCG5ZE0D70F", "کرج", 1, new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8270), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8270), 1L, "01GZTT98N8S8TE5J1WE205Q4WV", true },
                    { "01H1K9D1EMVVA8624N317FGC8D", "شیراز", 1, new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8250), new DateTime(2023, 5, 29, 8, 18, 40, 724, DateTimeKind.Utc).AddTicks(8250), 1L, "01GZTMF256K84ZGQFMWRB6VTV9", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMCMZE7BKDS4XAYMKD");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMF9WSH7JE0S7CG4BX");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMGC8PQTA1CETMW6ZM");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMHTK7WHCG5ZE0D70F");

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMVVA8624N317FGC8D");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EM0ETHJXSCSCVAA279");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EM2HNY8V6FMBJ8KNGJ");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EM3V9V0YQ24VWQH3NW");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EM4B4CX6C4NNEM7758");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EM4G2AZKW55G0XXY4K");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EM4VCR6P076HZP9NE0");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EM5F4CA14SHBQY5A3M");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EM5RX3H602KTN8B645");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EM6F55N6Y6KGWFN9T6");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EM90RG4C1EEWTMV7T7");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMAQX3TWKE4E2QYF7D");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMB12ERVXGDF2H1CTN");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMB464J1AXYQD5M1S3");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMFQEMR64YSEWW97KQ");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMGDCWYDZEWS9JEM7S");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMJ26V58SN60PVHVKB");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMKH817CEGRZM1C1CZ");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMMCQ9RVJ3ND78RXGZ");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMN9WZRNTXJA9B2KCK");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMNJDGMT1C8XZBKDFA");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMPTXCDES80PH5VK17");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMT7FWNBAEJXNMMR5J");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMVCW72SFKRW8EX78W");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMVFQ9N0RPTG9ZM5FW");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMVN4RWA5CB93GNMBA");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMWANWYD74B58CS011");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMXJS0W9WM8J4NNWQH");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01H1K9D1EMXWHRAJGAH13Q7S2A");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01GZTMF256K84ZGQFMWRB6VTV9");

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: "01GZTT98N8S8TE5J1WE205Q4WV");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: "01GZTM8DSTQH037TNTFSK9RX9W");
        }
    }
}
