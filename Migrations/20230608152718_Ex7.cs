using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class Ex7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "banners",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    photo = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'inactive')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_banners_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "brands",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'active')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brands_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "coupons",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    type = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false, defaultValueSql: "(N'fixed')"),
                    value = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'inactive')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupons_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "failed_jobs",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    connection = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    queue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    payload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exception = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    failed_at = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_failed_jobs_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    photo = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    phone = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    read_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_messages_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", fixedLength: true, maxLength: 36, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    notifiable_type = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    notifiable_id = table.Column<long>(type: "bigint", nullable: false),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    read_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "post_categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'active')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_categories_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "post_tags",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'active')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_tags_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "settings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    short_des = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logo = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    photo = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    address = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    email = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_settings_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "shippings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    price = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'active')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shippings_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    email = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    email_verified_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    password = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    photo = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    role = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, defaultValueSql: "(N'user')"),
                    provider = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    provider_id = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'active')"),
                    remember_token = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    is_parent = table.Column<short>(type: "smallint", nullable: false, defaultValueSql: "((1))"),
                    parent_id = table.Column<long>(type: "bigint", nullable: true),
                    added_by = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'inactive')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories_id", x => x.id);
                    table.ForeignKey(
                        name: "categories$categories_added_by_foreign",
                        column: x => x.added_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "categories$categories_parent_id_foreign",
                        column: x => x.parent_id,
                        principalTable: "categories",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_number = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    sub_total = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    shipping_id = table.Column<long>(type: "bigint", nullable: true),
                    coupon = table.Column<decimal>(type: "numeric(8,2)", nullable: true),
                    total_amount = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    payment_method = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false, defaultValueSql: "(N'cod')"),
                    payment_status = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false, defaultValueSql: "(N'unpaid')"),
                    status = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false, defaultValueSql: "(N'new')"),
                    first_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    email = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    phone = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    country = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    post_code = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders_id", x => x.id);
                    table.ForeignKey(
                        name: "orders$orders_shipping_id_foreign",
                        column: x => x.shipping_id,
                        principalTable: "shippings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "orders$orders_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quote = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    tags = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true),
                    post_cat_id = table.Column<long>(type: "bigint", nullable: true),
                    post_tag_id = table.Column<long>(type: "bigint", nullable: true),
                    added_by = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'active')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts_id", x => x.id);
                    table.ForeignKey(
                        name: "posts$posts_added_by_foreign",
                        column: x => x.added_by,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "posts$posts_post_cat_id_foreign",
                        column: x => x.post_cat_id,
                        principalTable: "post_categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "posts$posts_post_tag_id_foreign",
                        column: x => x.post_tag_id,
                        principalTable: "post_tags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    slug = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: false),
                    summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    photo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false, defaultValueSql: "((1))"),
                    size = table.Column<string>(type: "nvarchar(191)", maxLength: 191, nullable: true, defaultValueSql: "(N'M')"),
                    condition = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false, defaultValueSql: "(N'default')"),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'inactive')"),
                    price = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    discount = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    is_featured = table.Column<short>(type: "smallint", nullable: false),
                    cat_id = table.Column<long>(type: "bigint", nullable: true),
                    child_cat_id = table.Column<long>(type: "bigint", nullable: true),
                    brand_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products_id", x => x.id);
                    table.ForeignKey(
                        name: "products$products_brand_id_foreign",
                        column: x => x.brand_id,
                        principalTable: "brands",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "products$products_cat_id_foreign",
                        column: x => x.cat_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "post_comments",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    post_id = table.Column<long>(type: "bigint", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'active')"),
                    replied_comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parent_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post_comments_id", x => x.id);
                    table.ForeignKey(
                        name: "post_comments$post_comments_post_id_foreign",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "post_comments$post_comments_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    price = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false, defaultValueSql: "(N'new')"),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts_id", x => x.id);
                    table.ForeignKey(
                        name: "carts$carts_order_id_foreign",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "carts$carts_product_id_foreign",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "carts$carts_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_reviews",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    product_id = table.Column<long>(type: "bigint", nullable: true),
                    rate = table.Column<short>(type: "smallint", nullable: false),
                    review = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false, defaultValueSql: "(N'active')"),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_reviews_id", x => x.id);
                    table.ForeignKey(
                        name: "product_reviews$product_reviews_product_id_foreign",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "product_reviews$product_reviews_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "wishlists",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<long>(type: "bigint", nullable: false),
                    cart_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    price = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<decimal>(type: "numeric(8,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: true),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wishlists_id", x => x.id);
                    table.ForeignKey(
                        name: "wishlists$wishlists_cart_id_foreign",
                        column: x => x.cart_id,
                        principalTable: "carts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "wishlists$wishlists_product_id_foreign",
                        column: x => x.product_id,
                        principalTable: "products",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "wishlists$wishlists_user_id_foreign",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "banners$banners_slug_unique",
                table: "banners",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "brands$brands_slug_unique",
                table: "brands",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "carts_order_id_foreign",
                table: "carts",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "carts_product_id_foreign",
                table: "carts",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "carts_user_id_foreign",
                table: "carts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "categories_added_by_foreign",
                table: "categories",
                column: "added_by");

            migrationBuilder.CreateIndex(
                name: "categories_parent_id_foreign",
                table: "categories",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "categories$categories_slug_unique",
                table: "categories",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "coupons$coupons_code_unique",
                table: "coupons",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "notifications_notifiable_type_notifiable_id_index",
                table: "notifications",
                columns: new[] { "notifiable_type", "notifiable_id" });

            migrationBuilder.CreateIndex(
                name: "orders_shipping_id_foreign",
                table: "orders",
                column: "shipping_id");

            migrationBuilder.CreateIndex(
                name: "orders_user_id_foreign",
                table: "orders",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "orders$orders_order_number_unique",
                table: "orders",
                column: "order_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "post_categories$post_categories_slug_unique",
                table: "post_categories",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "post_comments_post_id_foreign",
                table: "post_comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "post_comments_user_id_foreign",
                table: "post_comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "post_tags$post_tags_slug_unique",
                table: "post_tags",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "posts_added_by_foreign",
                table: "posts",
                column: "added_by");

            migrationBuilder.CreateIndex(
                name: "posts_post_cat_id_foreign",
                table: "posts",
                column: "post_cat_id");

            migrationBuilder.CreateIndex(
                name: "posts_post_tag_id_foreign",
                table: "posts",
                column: "post_tag_id");

            migrationBuilder.CreateIndex(
                name: "posts$posts_slug_unique",
                table: "posts",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "product_reviews_product_id_foreign",
                table: "product_reviews",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "product_reviews_user_id_foreign",
                table: "product_reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "products_brand_id_foreign",
                table: "products",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "products_cat_id_foreign",
                table: "products",
                column: "cat_id");

            migrationBuilder.CreateIndex(
                name: "products$products_slug_unique",
                table: "products",
                column: "slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "users$users_email_unique",
                table: "users",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "wishlists_cart_id_foreign",
                table: "wishlists",
                column: "cart_id");

            migrationBuilder.CreateIndex(
                name: "wishlists_product_id_foreign",
                table: "wishlists",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "wishlists_user_id_foreign",
                table: "wishlists",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "banners");

            migrationBuilder.DropTable(
                name: "coupons");

            migrationBuilder.DropTable(
                name: "failed_jobs");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "post_comments");

            migrationBuilder.DropTable(
                name: "product_reviews");

            migrationBuilder.DropTable(
                name: "settings");

            migrationBuilder.DropTable(
                name: "wishlists");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "post_categories");

            migrationBuilder.DropTable(
                name: "post_tags");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "shippings");

            migrationBuilder.DropTable(
                name: "brands");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
