using Npgsql.EntityFrameworkCore.PostgreSQL.TestUtilities;

namespace Npgsql.EntityFrameworkCore.PostgreSQL.Query;

public class PrimitiveCollectionsQueryNpgsqlTest : PrimitiveCollectionsQueryRelationalTestBase<
    PrimitiveCollectionsQueryNpgsqlTest.PrimitiveCollectionsQueryNpgsqlFixture>
{
    public PrimitiveCollectionsQueryNpgsqlTest(PrimitiveCollectionsQueryNpgsqlFixture fixture, ITestOutputHelper testOutputHelper)
        : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    public override async Task Inline_collection_of_ints_Contains(bool async)
    {
        await base.Inline_collection_of_ints_Contains(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Int" IN (10, 999)
""");
    }

    public override async Task Inline_collection_of_nullable_ints_Contains(bool async)
    {
        await base.Inline_collection_of_nullable_ints_Contains(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."NullableInt" IN (10, 999)
""");
    }

    public override async Task Inline_collection_of_nullable_ints_Contains_null(bool async)
    {
        await base.Inline_collection_of_nullable_ints_Contains_null(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."NullableInt" IS NULL OR p."NullableInt" = 999
""");
    }

    public override async Task Inline_collection_Count_with_zero_values(bool async)
    {
        await base.Inline_collection_Count_with_zero_values(async);

        AssertSql();
    }

    public override async Task Inline_collection_Count_with_one_value(bool async)
    {
        await base.Inline_collection_Count_with_one_value(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (VALUES (2::int)) AS v("Value")
    WHERE v."Value" > p."Id") = 1
""");
    }

    public override async Task Inline_collection_Count_with_two_values(bool async)
    {
        await base.Inline_collection_Count_with_two_values(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (VALUES (2::int), (999)) AS v("Value")
    WHERE v."Value" > p."Id") = 1
""");
    }

    public override async Task Inline_collection_Count_with_three_values(bool async)
    {
        await base.Inline_collection_Count_with_three_values(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (VALUES (2::int), (999), (1000)) AS v("Value")
    WHERE v."Value" > p."Id") = 2
""");
    }

    public override async Task Inline_collection_Contains_with_zero_values(bool async)
    {
        await base.Inline_collection_Contains_with_zero_values(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE FALSE
""");
    }

    public override async Task Inline_collection_Contains_with_one_value(bool async)
    {
        await base.Inline_collection_Contains_with_one_value(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Id" = 2
""");
    }

    public override async Task Inline_collection_Contains_with_two_values(bool async)
    {
        await base.Inline_collection_Contains_with_two_values(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Id" IN (2, 999)
""");
    }

    public override async Task Inline_collection_Contains_with_three_values(bool async)
    {
        await base.Inline_collection_Contains_with_three_values(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Id" IN (2, 999, 1000)
""");
    }

    public override async Task Inline_collection_Contains_with_all_parameters(bool async)
    {
        await base.Inline_collection_Contains_with_all_parameters(async);

        AssertSql(
            """
@__i_0='2'
@__j_1='999'

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Id" IN (@__i_0, @__j_1)
""");
    }

    public override async Task Inline_collection_Contains_with_constant_and_parameter(bool async)
    {
        await base.Inline_collection_Contains_with_constant_and_parameter(async);

        AssertSql(
            """
@__j_0='999'

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Id" IN (2, @__j_0)
""");
    }

    public override async Task Inline_collection_Contains_with_mixed_value_types(bool async)
    {
        await base.Inline_collection_Contains_with_mixed_value_types(async);

        AssertSql(
            """
@__i_0='11'

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Int" IN (999, @__i_0, p."Id", p."Id" + p."Int")
""");
    }

    public override async Task Inline_collection_List_Contains_with_mixed_value_types(bool async)
    {
        await base.Inline_collection_List_Contains_with_mixed_value_types(async);

        AssertSql(
            """
@__i_0='11'

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Int" IN (999, @__i_0, p."Id", p."Id" + p."Int")
""");
    }

    public override async Task Inline_collection_Contains_as_Any_with_predicate(bool async)
    {
        await base.Inline_collection_Contains_as_Any_with_predicate(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Id" IN (2, 999)
""");
    }

    public override async Task Inline_collection_negated_Contains_as_All(bool async)
    {
        await base.Inline_collection_negated_Contains_as_All(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Id" NOT IN (2, 999)
""");
    }

    public override async Task Inline_collection_Min_with_two_values(bool async)
    {
        await base.Inline_collection_Min_with_two_values(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE LEAST(30, p."Int") = 30
""");
    }

    public override async Task Inline_collection_List_Min_with_two_values(bool async)
    {
        await base.Inline_collection_List_Min_with_two_values(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE LEAST(30, p."Int") = 30
""");
    }

    public override async Task Inline_collection_Max_with_two_values(bool async)
    {
        await base.Inline_collection_Max_with_two_values(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE GREATEST(30, p."Int") = 30
""");
    }

    public override async Task Inline_collection_List_Max_with_two_values(bool async)
    {
        await base.Inline_collection_List_Max_with_two_values(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE GREATEST(30, p."Int") = 30
""");
    }

    public override async Task Inline_collection_Min_with_three_values(bool async)
    {
        await base.Inline_collection_Min_with_three_values(async);

        AssertSql(
            """
@__i_0='25'

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE LEAST(30, p."Int", @__i_0) = 25
""");
    }

    public override async Task Inline_collection_List_Min_with_three_values(bool async)
    {
        await base.Inline_collection_List_Min_with_three_values(async);

        AssertSql(
            """
@__i_0='25'

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE LEAST(30, p."Int", @__i_0) = 25
""");
    }

    public override async Task Inline_collection_Max_with_three_values(bool async)
    {
        await base.Inline_collection_Max_with_three_values(async);

        AssertSql(
            """
@__i_0='35'

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE GREATEST(30, p."Int", @__i_0) = 35
""");
    }

    public override async Task Inline_collection_List_Max_with_three_values(bool async)
    {
        await base.Inline_collection_List_Max_with_three_values(async);

        AssertSql(
            """
@__i_0='35'

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE GREATEST(30, p."Int", @__i_0) = 35
""");
    }

    public override async Task Inline_collection_of_nullable_value_type_Min(bool async)
    {
        await base.Inline_collection_of_nullable_value_type_Min(async);

        AssertSql(
            """
@__i_0='25' (Nullable = true)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE LEAST(30, p."Int", @__i_0) = 25
""");
    }

    public override async Task Inline_collection_of_nullable_value_type_Max(bool async)
    {
        await base.Inline_collection_of_nullable_value_type_Max(async);

        AssertSql(
            """
@__i_0='35' (Nullable = true)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE GREATEST(30, p."Int", @__i_0) = 35
""");
    }

    public override async Task Inline_collection_of_nullable_value_type_with_null_Min(bool async)
    {
        await base.Inline_collection_of_nullable_value_type_with_null_Min(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE LEAST(30, p."NullableInt", NULL) = 30
""");
    }

    public override async Task Inline_collection_of_nullable_value_type_with_null_Max(bool async)
    {
        await base.Inline_collection_of_nullable_value_type_with_null_Max(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE GREATEST(30, p."NullableInt", NULL) = 30
""");
    }

        public override async Task Inline_collection_with_single_parameter_element_Contains(bool async)
    {
        await base.Inline_collection_with_single_parameter_element_Contains(async);

        AssertSql(
            """
@__i_0='2'

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Id" = @__i_0
""");
    }

    public override async Task Inline_collection_with_single_parameter_element_Count(bool async)
    {
        await base.Inline_collection_with_single_parameter_element_Count(async);

        AssertSql(
            """
@__i_0='2'

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (VALUES (@__i_0::int)) AS v("Value")
    WHERE v."Value" > p."Id") = 1
""");
    }

    public override async Task Inline_collection_Contains_with_EF_Parameter(bool async)
    {
        await base.Inline_collection_Contains_with_EF_Parameter(async);

        AssertSql(
            """
@__p_0={ '2', '999', '1000' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Id" = ANY (@__p_0)
""");
    }

    public override async Task Inline_collection_Count_with_column_predicate_with_EF_Parameter(bool async)
    {
        await base.Inline_collection_Count_with_column_predicate_with_EF_Parameter(async);

        AssertSql(
            """
@__p_0={ '2', '999', '1000' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM unnest(@__p_0) AS p0(value)
    WHERE p0.value > p."Id") = 2
""");
    }

    public override async Task Parameter_collection_Count(bool async)
    {
        await base.Parameter_collection_Count(async);

        AssertSql(
            """
@__ids_0={ '2', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM unnest(@__ids_0) AS i(value)
    WHERE i.value > p."Id") = 1
""");
    }

    public override async Task Parameter_collection_of_ints_Contains_int(bool async)
    {
        await base.Parameter_collection_of_ints_Contains_int(async);

        AssertSql(
            """
@__ints_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Int" = ANY (@__ints_0)
""",
            //
            """
@__ints_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE NOT (p."Int" = ANY (@__ints_0) AND p."Int" = ANY (@__ints_0) IS NOT NULL)
""");
    }

    public override async Task Parameter_collection_HashSet_of_ints_Contains_int(bool async)
    {
        await base.Parameter_collection_HashSet_of_ints_Contains_int(async);

        AssertSql(
            """
@__ints_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Int" = ANY (@__ints_0)
""",
            //
            """
@__ints_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE NOT (p."Int" = ANY (@__ints_0) AND p."Int" = ANY (@__ints_0) IS NOT NULL)
""");
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public virtual async Task Parameter_collection_HashSet_with_value_converter_Contains(bool async)
    {
        HashSet<MyEnum> enums = [MyEnum.Value1, MyEnum.Value4];

        await AssertQuery(
            async,
            ss => ss.Set<PrimitiveCollectionsEntity>().Where(c => enums.Contains(c.Enum)));

        AssertSql(
            """
@__enums_0={ '0', '3' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Enum" = ANY (@__enums_0)
""");
    }

    public override async Task Parameter_collection_of_ints_Contains_nullable_int(bool async)
    {
        await base.Parameter_collection_of_ints_Contains_nullable_int(async);

        AssertSql(
            """
@__ints_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."NullableInt" = ANY (@__ints_0) OR (p."NullableInt" IS NULL AND array_position(@__ints_0, NULL) IS NOT NULL)
""",
            //
            """
@__ints_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE NOT (p."NullableInt" = ANY (@__ints_0) AND p."NullableInt" = ANY (@__ints_0) IS NOT NULL) AND (p."NullableInt" IS NOT NULL OR array_position(@__ints_0, NULL) IS NULL)
""");
    }

    public override async Task Parameter_collection_of_nullable_ints_Contains_int(bool async)
    {
        await base.Parameter_collection_of_nullable_ints_Contains_int(async);

        AssertSql(
            """
@__nullableInts_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Int" = ANY (@__nullableInts_0)
""",
            //
            """
@__nullableInts_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE NOT (p."Int" = ANY (@__nullableInts_0) AND p."Int" = ANY (@__nullableInts_0) IS NOT NULL)
""");
    }

    public override async Task Parameter_collection_of_nullable_ints_Contains_nullable_int(bool async)
    {
        await base.Parameter_collection_of_nullable_ints_Contains_nullable_int(async);

        AssertSql(
            """
@__nullableInts_0={ NULL, '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."NullableInt" = ANY (@__nullableInts_0) OR (p."NullableInt" IS NULL AND array_position(@__nullableInts_0, NULL) IS NOT NULL)
""",
            //
            """
@__nullableInts_0={ NULL, '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE NOT (p."NullableInt" = ANY (@__nullableInts_0) AND p."NullableInt" = ANY (@__nullableInts_0) IS NOT NULL) AND (p."NullableInt" IS NOT NULL OR array_position(@__nullableInts_0, NULL) IS NULL)
""");
    }

    public override async Task Parameter_collection_of_strings_Contains_string(bool async)
    {
        await base.Parameter_collection_of_strings_Contains_string(async);

        AssertSql(
            """
@__strings_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."String" = ANY (@__strings_0)
""",
            //
            """
@__strings_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE NOT (p."String" = ANY (@__strings_0) AND p."String" = ANY (@__strings_0) IS NOT NULL)
""");
    }

    public override async Task Parameter_collection_of_strings_Contains_nullable_string(bool async)
    {
        await base.Parameter_collection_of_strings_Contains_nullable_string(async);

        AssertSql(
            """
@__strings_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."NullableString" = ANY (@__strings_0) OR (p."NullableString" IS NULL AND array_position(@__strings_0, NULL) IS NOT NULL)
""",
            //
            """
@__strings_0={ '10', '999' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE NOT (p."NullableString" = ANY (@__strings_0) AND p."NullableString" = ANY (@__strings_0) IS NOT NULL) AND (p."NullableString" IS NOT NULL OR array_position(@__strings_0, NULL) IS NULL)
""");
    }

    public override async Task Parameter_collection_of_nullable_strings_Contains_string(bool async)
    {
        await base.Parameter_collection_of_nullable_strings_Contains_string(async);

        AssertSql(
            """
@__strings_0={ '10', NULL } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."String" = ANY (@__strings_0)
""",
            //
            """
@__strings_0={ '10', NULL } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE NOT (p."String" = ANY (@__strings_0) AND p."String" = ANY (@__strings_0) IS NOT NULL)
""");
    }

    public override async Task Parameter_collection_of_nullable_strings_Contains_nullable_string(bool async)
    {
        await base.Parameter_collection_of_nullable_strings_Contains_nullable_string(async);

        AssertSql(
            """
@__strings_0={ '999', NULL } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."NullableString" = ANY (@__strings_0) OR (p."NullableString" IS NULL AND array_position(@__strings_0, NULL) IS NOT NULL)
""",
            //
            """
@__strings_0={ '999', NULL } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE NOT (p."NullableString" = ANY (@__strings_0) AND p."NullableString" = ANY (@__strings_0) IS NOT NULL) AND (p."NullableString" IS NOT NULL OR array_position(@__strings_0, NULL) IS NULL)
""");
    }

    public override async Task Parameter_collection_of_DateTimes_Contains(bool async)
    {
        await base.Parameter_collection_of_DateTimes_Contains(async);

        AssertSql(
            """
@__dateTimes_0={ '2020-01-10T12:30:00.0000000Z', '9999-01-01T00:00:00.0000000Z' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."DateTime" = ANY (@__dateTimes_0)
""");
    }

    public override async Task Parameter_collection_of_bools_Contains(bool async)
    {
        await base.Parameter_collection_of_bools_Contains(async);

        AssertSql(
            """
@__bools_0={ 'True' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Bool" = ANY (@__bools_0)
""");
    }

    public override async Task Parameter_collection_of_enums_Contains(bool async)
    {
        await base.Parameter_collection_of_enums_Contains(async);

        AssertSql(
            """
@__enums_0={ '0', '3' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Enum" = ANY (@__enums_0)
""");
    }

    public override async Task Parameter_collection_null_Contains(bool async)
    {
        await base.Parameter_collection_null_Contains(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Int" = ANY (NULL)
""");
    }

    public override async Task Parameter_collection_Contains_with_EF_Constant(bool async)
    {
        await base.Parameter_collection_Contains_with_EF_Constant(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Id" IN (2, 999, 1000)
""");
    }

    public override async Task Parameter_collection_Where_with_EF_Constant_Where_Any(bool async)
    {
        await base.Parameter_collection_Where_with_EF_Constant_Where_Any(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE EXISTS (
    SELECT 1
    FROM (VALUES (2), (999), (1000)) AS i("Value")
    WHERE i."Value" > 0)
""");
    }

    public override async Task Parameter_collection_Count_with_column_predicate_with_EF_Constant(bool async)
    {
        await base.Parameter_collection_Count_with_column_predicate_with_EF_Constant(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (VALUES (2), (999), (1000)) AS i("Value")
    WHERE i."Value" > p."Id") = 2
""");
    }

    [ConditionalTheory] // #3012
    [MinimumPostgresVersion(14, 0)] // Multiranges were introduced in PostgreSQL 14
    [MemberData(nameof(IsAsyncData))]
    public virtual async Task Parameter_collection_of_ranges_Contains(bool async)
    {
        var ranges = new NpgsqlRange<int>[]
        {
            new(5, 15),
            new(40, 50)
        };

        await AssertQuery(
            async,
            ss => ss.Set<PrimitiveCollectionsEntity>().Where(e => ranges.Contains(e.Int)),
            ss => ss.Set<PrimitiveCollectionsEntity>().Where(c => ranges.Any(p => p.LowerBound <= c.Int && p.UpperBound >= c.Int)));

        AssertSql(
            """
@__ranges_0={ '[5,15]', '[40,50]' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE @__ranges_0 @> p."Int"
""");
    }

    public override async Task Column_collection_of_ints_Contains(bool async)
    {
        await base.Column_collection_of_ints_Contains(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Ints" @> ARRAY[10]::integer[]
""");
    }

    public override async Task Column_collection_of_nullable_ints_Contains(bool async)
    {
        await base.Column_collection_of_nullable_ints_Contains(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."NullableInts" @> ARRAY[10]::integer[]
""");
    }

    public override async Task Column_collection_of_nullable_ints_Contains_null(bool async)
    {
        await base.Column_collection_of_nullable_ints_Contains_null(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE array_position(p."NullableInts", NULL) IS NOT NULL
""");
    }

    public override async Task Column_collection_of_strings_contains_null(bool async)
    {
        await base.Column_collection_of_strings_contains_null(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE array_position(p."Strings", NULL) IS NOT NULL
""");
    }

    public override async Task Column_collection_of_nullable_strings_contains_null(bool async)
    {
        await base.Column_collection_of_nullable_strings_contains_null(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE array_position(p."NullableStrings", NULL) IS NOT NULL
""");
    }

    public override async Task Column_collection_of_bools_Contains(bool async)
    {
        await base.Column_collection_of_bools_Contains(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Bools" @> ARRAY[TRUE]::boolean[]
""");
    }

    public override async Task Column_collection_Count_method(bool async)
    {
        await base.Column_collection_Count_method(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE cardinality(p."Ints") = 2
""");
    }

    public override async Task Column_collection_Length(bool async)
    {
        await base.Column_collection_Length(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE cardinality(p."Ints") = 2
""");
    }

    public override async Task Column_collection_Count_with_predicate(bool async)
    {
        await base.Column_collection_Count_with_predicate(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM unnest(p."Ints") AS i(value)
    WHERE i.value > 1) = 2
""");
    }

    public override async Task Column_collection_Where_Count(bool async)
    {
        await base.Column_collection_Where_Count(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM unnest(p."Ints") AS i(value)
    WHERE i.value > 1) = 2
""");
    }

    public override async Task Column_collection_index_int(bool async)
    {
        await base.Column_collection_index_int(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Ints"[2] = 10
""");
    }

    public override async Task Column_collection_index_string(bool async)
    {
        await base.Column_collection_index_string(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Strings"[2] = '10'
""");
    }

    public override async Task Column_collection_index_datetime(bool async)
    {
        await base.Column_collection_index_datetime(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."DateTimes"[2] = TIMESTAMPTZ '2020-01-10T12:30:00Z'
""");
    }

    public override async Task Column_collection_index_beyond_end(bool async)
    {
        await base.Column_collection_index_beyond_end(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Ints"[1000] = 10
""");
    }

    public override async Task Nullable_reference_column_collection_index_equals_nullable_column(bool async)
    {
        await base.Nullable_reference_column_collection_index_equals_nullable_column(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."NullableStrings"[3] = p."NullableString" OR (p."NullableStrings"[3] IS NULL AND p."NullableString" IS NULL)
""");
    }

    public override async Task Non_nullable_reference_column_collection_index_equals_nullable_column(bool async)
    {
        await base.Non_nullable_reference_column_collection_index_equals_nullable_column(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE cardinality(p."Strings") > 0 AND p."Strings"[2] = p."NullableString"
""");
    }

    public override async Task Inline_collection_index_Column(bool async)
    {
        await base.Inline_collection_index_Column(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT v."Value"
    FROM (VALUES (0, 1::int), (1, 2), (2, 3)) AS v(_ord, "Value")
    ORDER BY v._ord NULLS FIRST
    LIMIT 1 OFFSET p."Int") = 1
""");
    }

    public override async Task Inline_collection_value_index_Column(bool async)
    {
        await base.Inline_collection_value_index_Column(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT v."Value"
    FROM (VALUES (0, 1::int), (1, p."Int"), (2, 3)) AS v(_ord, "Value")
    ORDER BY v._ord NULLS FIRST
    LIMIT 1 OFFSET p."Int") = 1
""");
    }

    public override async Task Inline_collection_List_value_index_Column(bool async)
    {
        await base.Inline_collection_List_value_index_Column(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT v."Value"
    FROM (VALUES (0, 1::int), (1, p."Int"), (2, 3)) AS v(_ord, "Value")
    ORDER BY v._ord NULLS FIRST
    LIMIT 1 OFFSET p."Int") = 1
""");
    }

    public override async Task Parameter_collection_index_Column_equal_Column(bool async)
    {
        await base.Parameter_collection_index_Column_equal_Column(async);

        AssertSql(
            """
@__ints_0={ '0', '2', '3' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE @__ints_0[p."Int" + 1] = p."Int"
""");
    }

    public override async Task Parameter_collection_index_Column_equal_constant(bool async)
    {
        await base.Parameter_collection_index_Column_equal_constant(async);

        AssertSql(
            """
@__ints_0={ '1', '2', '3' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE @__ints_0[p."Int" + 1] = 1
""");
    }

    public override async Task Column_collection_ElementAt(bool async)
    {
        await base.Column_collection_ElementAt(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Ints"[2] = 10
""");
    }

        public override async Task Column_collection_First(bool async)
    {
        await base.Column_collection_First(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT i.value
    FROM unnest(p."Ints") AS i(value)
    LIMIT 1) = 1
""");
    }

    public override async Task Column_collection_FirstOrDefault(bool async)
    {
        await base.Column_collection_FirstOrDefault(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE COALESCE((
    SELECT i.value
    FROM unnest(p."Ints") AS i(value)
    LIMIT 1), 0) = 1
""");
    }

    public override async Task Column_collection_Single(bool async)
    {
        await base.Column_collection_Single(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT i.value
    FROM unnest(p."Ints") AS i(value)
    LIMIT 1) = 1
""");
    }

    public override async Task Column_collection_SingleOrDefault(bool async)
    {
        await base.Column_collection_SingleOrDefault(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE COALESCE((
    SELECT i.value
    FROM unnest(p."Ints") AS i(value)
    LIMIT 1), 0) = 1
""");
    }

    public override async Task Column_collection_Skip(bool async)
    {
        await base.Column_collection_Skip(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE cardinality(p."Ints"[2:]) = 2
""");
    }

    public override async Task Column_collection_Take(bool async)
    {
        await base.Column_collection_Take(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE 11 = ANY (p."Ints"[:2])
""");
    }

    public override async Task Column_collection_Skip_Take(bool async)
    {
        await base.Column_collection_Skip_Take(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE 11 = ANY (p."Ints"[2:3])
""");
    }

        public override async Task Column_collection_Where_Skip(bool async)
    {
        await base.Column_collection_Where_Skip(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT 1
        FROM unnest(p."Ints") AS i(value)
        WHERE i.value > 1
        OFFSET 1
    ) AS i0) = 3
""");
    }

    public override async Task Column_collection_Where_Take(bool async)
    {
        await base.Column_collection_Where_Take(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT 1
        FROM unnest(p."Ints") AS i(value)
        WHERE i.value > 1
        LIMIT 2
    ) AS i0) = 2
""");
    }

    public override async Task Column_collection_Where_Skip_Take(bool async)
    {
        await base.Column_collection_Where_Skip_Take(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT 1
        FROM unnest(p."Ints") AS i(value)
        WHERE i.value > 1
        LIMIT 2 OFFSET 1
    ) AS i0) = 1
""");
    }

    public override async Task Column_collection_Contains_over_subquery(bool async)
    {
        await base.Column_collection_Contains_over_subquery(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE 11 IN (
    SELECT i.value
    FROM unnest(p."Ints") AS i(value)
    WHERE i.value > 1
)
""");
    }

    public override async Task Column_collection_OrderByDescending_ElementAt(bool async)
    {
        await base.Column_collection_OrderByDescending_ElementAt(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT i.value
    FROM unnest(p."Ints") AS i(value)
    ORDER BY i.value DESC NULLS LAST
    LIMIT 1 OFFSET 0) = 111
""");
    }

    public override async Task Column_collection_Where_ElementAt(bool async)
    {
        await base.Column_collection_Where_ElementAt(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT i.value
    FROM unnest(p."Ints") AS i(value)
    WHERE i.value > 1
    LIMIT 1 OFFSET 0) = 11
""");
    }

    public override async Task Column_collection_Any(bool async)
    {
        await base.Column_collection_Any(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE cardinality(p."Ints") > 0
""");
    }

    public override async Task Column_collection_Distinct(bool async)
    {
        await base.Column_collection_Distinct(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT DISTINCT i.value
        FROM unnest(p."Ints") AS i(value)
    ) AS i0) = 3
""");
    }

    public override async Task Column_collection_SelectMany(bool async)
    {
        await base.Column_collection_SelectMany(async);

        AssertSql(
            """
SELECT i.value
FROM "PrimitiveCollectionsEntity" AS p
JOIN LATERAL unnest(p."Ints") AS i(value) ON TRUE
""");
    }

    public override async Task Column_collection_SelectMany_with_filter(bool async)
    {
        await base.Column_collection_SelectMany_with_filter(async);

        AssertSql(
            """
SELECT i0.value
FROM "PrimitiveCollectionsEntity" AS p
JOIN LATERAL (
    SELECT i.value
    FROM unnest(p."Ints") AS i(value)
    WHERE i.value > 1
) AS i0 ON TRUE
""");
    }

    public override async Task Column_collection_SelectMany_with_Select_to_anonymous_type(bool async)
    {
        await base.Column_collection_SelectMany_with_Select_to_anonymous_type(async);

        AssertSql(
            """
SELECT i.value AS "Original", i.value + 1 AS "Incremented"
FROM "PrimitiveCollectionsEntity" AS p
JOIN LATERAL unnest(p."Ints") AS i(value) ON TRUE
""");
    }

    public override async Task Column_collection_projection_from_top_level(bool async)
    {
        await base.Column_collection_projection_from_top_level(async);

        AssertSql(
            """
SELECT p."Ints"
FROM "PrimitiveCollectionsEntity" AS p
ORDER BY p."Id" NULLS FIRST
""");
    }

    public override async Task Column_collection_Join_parameter_collection(bool async)
    {
        await base.Column_collection_Join_parameter_collection(async);

        AssertSql(
            """
@__ints_0={ '11', '111' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM unnest(p."Ints") AS i(value)
    INNER JOIN unnest(@__ints_0) AS i0(value) ON i.value = i0.value) = 2
""");
    }

    public override async Task Inline_collection_Join_ordered_column_collection(bool async)
    {
        await base.Inline_collection_Join_ordered_column_collection(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (VALUES (11::int), (111)) AS v("Value")
    INNER JOIN unnest(p."Ints") AS i(value) ON v."Value" = i.value) = 2
""");
    }

    public override async Task Parameter_collection_Concat_column_collection(bool async)
    {
        await base.Parameter_collection_Concat_column_collection(async);

        AssertSql(
            """
@__ints_0={ '11', '111' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE cardinality(@__ints_0 || p."Ints") = 2
""");
    }

    public override async Task Parameter_collection_with_type_inference_for_JsonScalarExpression(bool async)
    {
        await base.Parameter_collection_with_type_inference_for_JsonScalarExpression(async);

        AssertSql(
            """
@__values_0={ 'one', 'two' } (DbType = Object)

SELECT CASE
    WHEN p."Id" <> 0 THEN @__values_0[p."Int" % 2 + 1]
    ELSE 'foo'
END
FROM "PrimitiveCollectionsEntity" AS p
""");
    }

    public override async Task Column_collection_Union_parameter_collection(bool async)
    {
        await base.Column_collection_Union_parameter_collection(async);

        AssertSql(
            """
@__ints_0={ '11', '111' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT i.value
        FROM unnest(p."Ints") AS i(value)
        UNION
        SELECT i0.value
        FROM unnest(@__ints_0) AS i0(value)
    ) AS u) = 2
""");
    }

    public override async Task Column_collection_Intersect_inline_collection(bool async)
    {
        await base.Column_collection_Intersect_inline_collection(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT i.value
        FROM unnest(p."Ints") AS i(value)
        INTERSECT
        VALUES (11::int), (111)
    ) AS i0) = 2
""");
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public virtual async Task Column_collection_Intersect_Parameter_collection_Any(bool async)
    {
        var ints = new[] { 11, 12 };

        await AssertQuery(
            async,
            ss => ss.Set<PrimitiveCollectionsEntity>().Where(c => c.Ints.Intersect(ints).Any()));

        AssertSql(
            """
@__ints_0={ '11', '12' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Ints" && @__ints_0
""");
    }

    public override async Task Inline_collection_Except_column_collection(bool async)
    {
        await base.Inline_collection_Except_column_collection(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT v."Value"
        FROM (VALUES (11::int), (111)) AS v("Value")
        EXCEPT
        SELECT i.value AS "Value"
        FROM unnest(p."Ints") AS i(value)
    ) AS e
    WHERE e."Value" % 2 = 1) = 2
""");
    }

    public override async Task Column_collection_Where_Union(bool async)
    {
        await base.Column_collection_Where_Union(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT i.value
        FROM unnest(p."Ints") AS i(value)
        WHERE i.value > 100
        UNION
        VALUES (50::int)
    ) AS u) = 2
""");
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public virtual async Task Parameter_collection_Concat_Column_collection_Concat_parameter(bool async)
    {
        var ints1 = new[] { 11 };
        var ints2 = new[] { 12 };

        await AssertQuery(
            async,
            ss => ss.Set<PrimitiveCollectionsEntity>().Where(c => ints1.Concat(c.Ints).Concat(ints2).Count() == 4));

        AssertSql(
            """
@__ints1_0={ '11' } (DbType = Object)
@__ints2_1={ '12' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE cardinality(@__ints1_0 || p."Ints" || @__ints2_1) = 4
""");
    }

    public override async Task Column_collection_Concat_parameter_collection_equality_inline_collection(bool async)
    {
        await base.Column_collection_Concat_parameter_collection_equality_inline_collection(async);

        AssertSql();
    }

    public override async Task Column_collection_equality_parameter_collection(bool async)
    {
        await base.Column_collection_equality_parameter_collection(async);

        AssertSql(
            """
@__ints_0={ '1', '10' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Ints" = @__ints_0
""");
    }

    public override async Task Column_collection_equality_inline_collection(bool async)
    {
        await base.Column_collection_equality_inline_collection(async);

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Ints" = ARRAY[1,10]::integer[]
""");
    }

    public override async Task Column_collection_equality_inline_collection_with_parameters(bool async)
    {
        var (i, j) = (1, 10);

        await AssertQuery(
            async,
            ss => ss.Set<PrimitiveCollectionsEntity>().Where(c => c.Ints == new[] { i, j }),
            ss => ss.Set<PrimitiveCollectionsEntity>().Where(c => c.Ints.SequenceEqual(new[] { i, j })));

        AssertSql(
            """
@__i_0='1'
@__j_1='10'

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Ints" = ARRAY[@__i_0,@__j_1]::integer[]
""");
    }

    public override async Task Column_collection_Where_equality_inline_collection(bool async)
    {
        await base.Column_collection_Where_equality_inline_collection(async);

        AssertSql();
    }

    public override async Task Parameter_collection_in_subquery_Union_column_collection_as_compiled_query(bool async)
    {
        await base.Parameter_collection_in_subquery_Union_column_collection_as_compiled_query(async);

        AssertSql(
            """
@__ints={ '10', '111' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT i.value
        FROM unnest(@__ints[2:]) AS i(value)
        UNION
        SELECT i0.value
        FROM unnest(p."Ints") AS i0(value)
    ) AS u) = 3
""");
    }

    public override async Task Parameter_collection_in_subquery_Union_column_collection(bool async)
    {
        await base.Parameter_collection_in_subquery_Union_column_collection(async);

        AssertSql(
            """
@__Skip_0={ '111' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT s.value
        FROM unnest(@__Skip_0) AS s(value)
        UNION
        SELECT i.value
        FROM unnest(p."Ints") AS i(value)
    ) AS u) = 3
""");
    }

    public override async Task Parameter_collection_in_subquery_Union_column_collection_nested(bool async)
    {
        await base.Parameter_collection_in_subquery_Union_column_collection_nested(async);

        AssertSql(
            """
@__Skip_0={ '111' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT s.value
        FROM unnest(@__Skip_0) AS s(value)
        UNION
        SELECT i2.value
        FROM (
            SELECT i1.value
            FROM (
                SELECT DISTINCT i0.value
                FROM (
                    SELECT i.value
                    FROM unnest(p."Ints") AS i(value)
                    ORDER BY i.value NULLS FIRST
                    OFFSET 1
                ) AS i0
            ) AS i1
            ORDER BY i1.value DESC NULLS LAST
            LIMIT 20
        ) AS i2
    ) AS u) = 3
""");
    }

    public override void Parameter_collection_in_subquery_and_Convert_as_compiled_query()
    {
        base.Parameter_collection_in_subquery_and_Convert_as_compiled_query();

        AssertSql();
    }

    public override async Task Parameter_collection_in_subquery_Union_another_parameter_collection_as_compiled_query(bool async)
    {
        await base.Parameter_collection_in_subquery_Union_another_parameter_collection_as_compiled_query(async);

        AssertSql();
    }

    public override async Task Parameter_collection_in_subquery_Count_as_compiled_query(bool async)
    {
        await base.Parameter_collection_in_subquery_Count_as_compiled_query(async);

        AssertSql(
            """
@__ints={ '10', '111' } (DbType = Object)

SELECT count(*)::int
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM unnest(@__ints[2:]) AS i(value)
    WHERE i.value > p."Id") = 1
""");
    }

    public override async Task Column_collection_in_subquery_Union_parameter_collection(bool async)
    {
        await base.Column_collection_in_subquery_Union_parameter_collection(async);

        AssertSql(
            """
@__ints_0={ '10', '111' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE (
    SELECT count(*)::int
    FROM (
        SELECT i.value
        FROM unnest(p."Ints"[2:]) AS i(value)
        UNION
        SELECT i0.value
        FROM unnest(@__ints_0) AS i0(value)
    ) AS u) = 3
""");
    }

    public override async Task Project_collection_of_ints_simple(bool async)
    {
        await base.Project_collection_of_ints_simple(async);

        AssertSql(
            """
SELECT p."Ints"
FROM "PrimitiveCollectionsEntity" AS p
ORDER BY p."Id" NULLS FIRST
""");
    }

    public override async Task Project_collection_of_ints_ordered(bool async)
    {
        await base.Project_collection_of_ints_ordered(async);

        AssertSql(
            """
SELECT p."Id", i.value, i.ordinality
FROM "PrimitiveCollectionsEntity" AS p
LEFT JOIN LATERAL unnest(p."Ints") WITH ORDINALITY AS i(value) ON TRUE
ORDER BY p."Id" NULLS FIRST, i.value DESC NULLS LAST
""");
    }

    public override async Task Project_collection_of_datetimes_filtered(bool async)
    {
        await base.Project_collection_of_datetimes_filtered(async);

        AssertSql(
            """
SELECT p."Id", d0.value, d0.ordinality
FROM "PrimitiveCollectionsEntity" AS p
LEFT JOIN LATERAL (
    SELECT d.value, d.ordinality
    FROM unnest(p."DateTimes") WITH ORDINALITY AS d(value)
    WHERE date_part('day', d.value AT TIME ZONE 'UTC')::int <> 1
) AS d0 ON TRUE
ORDER BY p."Id" NULLS FIRST, d0.ordinality NULLS FIRST
""");
    }

    public override async Task Project_collection_of_nullable_ints_with_paging(bool async)
    {
        await base.Project_collection_of_nullable_ints_with_paging(async);

        AssertSql(
            """
SELECT p."Id", n.value, n.ordinality
FROM "PrimitiveCollectionsEntity" AS p
LEFT JOIN LATERAL unnest(p."NullableInts"[:20]) WITH ORDINALITY AS n(value) ON TRUE
ORDER BY p."Id" NULLS FIRST
""");
    }

    public override async Task Project_collection_of_nullable_ints_with_paging2(bool async)
    {
        await base.Project_collection_of_nullable_ints_with_paging2(async);

        AssertSql(
            """
SELECT p."Id", n0.value, n0.ordinality
FROM "PrimitiveCollectionsEntity" AS p
LEFT JOIN LATERAL (
    SELECT n.value, n.ordinality
    FROM unnest(p."NullableInts") WITH ORDINALITY AS n(value)
    ORDER BY n.value NULLS FIRST
    OFFSET 1
) AS n0 ON TRUE
ORDER BY p."Id" NULLS FIRST, n0.value NULLS FIRST
""");
    }

    public override async Task Project_collection_of_nullable_ints_with_paging3(bool async)
    {
        await base.Project_collection_of_nullable_ints_with_paging3(async);

        AssertSql(
            """
SELECT p."Id", n.value, n.ordinality
FROM "PrimitiveCollectionsEntity" AS p
LEFT JOIN LATERAL unnest(p."NullableInts"[3:]) WITH ORDINALITY AS n(value) ON TRUE
ORDER BY p."Id" NULLS FIRST
""");
    }

    public override async Task Project_collection_of_ints_with_distinct(bool async)
    {
        await base.Project_collection_of_ints_with_distinct(async);

        AssertSql(
            """
SELECT p."Id", i0.value
FROM "PrimitiveCollectionsEntity" AS p
LEFT JOIN LATERAL (
    SELECT DISTINCT i.value
    FROM unnest(p."Ints") AS i(value)
) AS i0 ON TRUE
ORDER BY p."Id" NULLS FIRST
""");
    }

    public override async Task Project_collection_of_nullable_ints_with_distinct(bool async)
    {
        await base.Project_collection_of_nullable_ints_with_distinct(async);

        AssertSql();
    }

    public override async Task Project_collection_of_ints_with_ToList_and_FirstOrDefault(bool async)
    {
        await base.Project_collection_of_ints_with_ToList_and_FirstOrDefault(async);

        AssertSql(
            """
SELECT p0."Id", i.value, i.ordinality
FROM (
    SELECT p."Id", p."Ints"
    FROM "PrimitiveCollectionsEntity" AS p
    ORDER BY p."Id" NULLS FIRST
    LIMIT 1
) AS p0
LEFT JOIN LATERAL unnest(p0."Ints") WITH ORDINALITY AS i(value) ON TRUE
ORDER BY p0."Id" NULLS FIRST, i.ordinality NULLS FIRST
""");
    }

    public override async Task Project_empty_collection_of_nullables_and_collection_only_containing_nulls(bool async)
    {
        await base.Project_empty_collection_of_nullables_and_collection_only_containing_nulls(async);

        AssertSql(
            """
SELECT p."Id", n1.value, n1.ordinality, n2.value, n2.ordinality
FROM "PrimitiveCollectionsEntity" AS p
LEFT JOIN LATERAL (
    SELECT n.value, n.ordinality
    FROM unnest(p."NullableInts") WITH ORDINALITY AS n(value)
    WHERE FALSE
) AS n1 ON TRUE
LEFT JOIN LATERAL (
    SELECT n0.value, n0.ordinality
    FROM unnest(p."NullableInts") WITH ORDINALITY AS n0(value)
    WHERE n0.value IS NULL
) AS n2 ON TRUE
ORDER BY p."Id" NULLS FIRST, n1.ordinality NULLS FIRST, n2.ordinality NULLS FIRST
""");
    }

    public override async Task Project_multiple_collections(bool async)
    {
        // Base implementation currently uses an Unspecified DateTime in the query, but we require a Utc one.
        await AssertQuery(
            async,
            ss => ss.Set<PrimitiveCollectionsEntity>().OrderBy(x => x.Id).Select(
                x => new
                {
                    Ints = x.Ints.ToList(),
                    OrderedInts = x.Ints.OrderByDescending(xx => xx).ToList(),
                    FilteredDateTimes = x.DateTimes.Where(xx => xx.Day != 1).ToList(),
                    FilteredDateTimes2 = x.DateTimes.Where(xx => xx > new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)).ToList()
                }),
            elementAsserter: (e, a) =>
            {
                AssertCollection(e.Ints, a.Ints, ordered: true);
                AssertCollection(e.OrderedInts, a.OrderedInts, ordered: true);
                AssertCollection(e.FilteredDateTimes, a.FilteredDateTimes, elementSorter: ee => ee);
                AssertCollection(e.FilteredDateTimes2, a.FilteredDateTimes2, elementSorter: ee => ee);
            },
            assertOrder: true);

        AssertSql(
            """
SELECT p."Id", i.value, i.ordinality, i0.value, i0.ordinality, d1.value, d1.ordinality, d2.value, d2.ordinality
FROM "PrimitiveCollectionsEntity" AS p
LEFT JOIN LATERAL unnest(p."Ints") WITH ORDINALITY AS i(value) ON TRUE
LEFT JOIN LATERAL unnest(p."Ints") WITH ORDINALITY AS i0(value) ON TRUE
LEFT JOIN LATERAL (
    SELECT d.value, d.ordinality
    FROM unnest(p."DateTimes") WITH ORDINALITY AS d(value)
    WHERE date_part('day', d.value AT TIME ZONE 'UTC')::int <> 1
) AS d1 ON TRUE
LEFT JOIN LATERAL (
    SELECT d0.value, d0.ordinality
    FROM unnest(p."DateTimes") WITH ORDINALITY AS d0(value)
    WHERE d0.value > TIMESTAMPTZ '2000-01-01T00:00:00Z'
) AS d2 ON TRUE
ORDER BY p."Id" NULLS FIRST, i.ordinality NULLS FIRST, i0.value DESC NULLS LAST, i0.ordinality NULLS FIRST, d1.ordinality NULLS FIRST, d2.ordinality NULLS FIRST
""");
    }

    public override async Task Project_primitive_collections_element(bool async)
    {
        await base.Project_primitive_collections_element(async);

        AssertSql(
            """
SELECT p."Ints"[1] AS "Indexer", p."DateTimes"[1] AS "EnumerableElementAt", p."Strings"[2] AS "QueryableElementAt"
FROM "PrimitiveCollectionsEntity" AS p
WHERE p."Id" < 4
ORDER BY p."Id" NULLS FIRST
""");
    }

    public override async Task Project_inline_collection(bool async)
    {
        await base.Project_inline_collection(async);

        AssertSql(
            """
SELECT ARRAY[p."String",'foo']::text[]
FROM "PrimitiveCollectionsEntity" AS p
""");
    }

    public override async Task Project_inline_collection_with_Union(bool async)
    {
        await base.Project_inline_collection_with_Union(async);

        AssertSql(
            """
SELECT p."Id", u."Value"
FROM "PrimitiveCollectionsEntity" AS p
LEFT JOIN LATERAL (
    SELECT v."Value"
    FROM (VALUES (p."String")) AS v("Value")
    UNION
    SELECT p0."String" AS "Value"
    FROM "PrimitiveCollectionsEntity" AS p0
) AS u ON TRUE
ORDER BY p."Id" NULLS FIRST
""");
    }

    public override async Task Project_inline_collection_with_Concat(bool async)
    {
        await base.Project_inline_collection_with_Concat(async);

        AssertSql();
    }

    public override async Task Nested_contains_with_Lists_and_no_inferred_type_mapping(bool async)
    {
        await base.Nested_contains_with_Lists_and_no_inferred_type_mapping(async);

        AssertSql(
            """
@__ints_0={ '1', '2', '3' } (DbType = Object)
@__strings_1={ 'one', 'two', 'three' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE CASE
    WHEN p."Int" = ANY (@__ints_0) THEN 'one'
    ELSE 'two'
END = ANY (@__strings_1)
""");
    }

    public override async Task Nested_contains_with_arrays_and_no_inferred_type_mapping(bool async)
    {
        await base.Nested_contains_with_arrays_and_no_inferred_type_mapping(async);

        AssertSql(
            """
@__ints_0={ '1', '2', '3' } (DbType = Object)
@__strings_1={ 'one', 'two', 'three' } (DbType = Object)

SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE CASE
    WHEN p."Int" = ANY (@__ints_0) THEN 'one'
    ELSE 'two'
END = ANY (@__strings_1)
""");
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public virtual async Task Array_remove(bool async)
    {
        await AssertQuery(
            async,
            // ReSharper disable once ReplaceWithSingleCallToCount
            ss => ss.Set<PrimitiveCollectionsEntity>().Where(e => e.Ints.Where(i => i != 1).Count() == 1));

        AssertSql(
            """
SELECT p."Id", p."Bool", p."Bools", p."DateTime", p."DateTimes", p."Enum", p."Enums", p."Int", p."Ints", p."NullableInt", p."NullableInts", p."NullableString", p."NullableStrings", p."String", p."Strings"
FROM "PrimitiveCollectionsEntity" AS p
WHERE cardinality(array_remove(p."Ints", 1)) = 1
""");
    }

    [ConditionalFact]
    public virtual void Check_all_tests_overridden()
        => TestHelpers.AssertAllMethodsOverridden(GetType());

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

    private PrimitiveCollectionsContext CreateContext()
        => Fixture.CreateContext();

    public class PrimitiveCollectionsQueryNpgsqlFixture : PrimitiveCollectionsQueryFixtureBase, ITestSqlLoggerFactory
    {
        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;

        protected override ITestStoreFactory TestStoreFactory
            => NpgsqlTestStoreFactory.Instance;
    }
}
