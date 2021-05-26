using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB.Models;
using PagedList;
using PagedList.Mvc;

namespace DemoDB.Controllers
{
    public class ProductsController : Controller
    {
        private DBSportStoreEntities db = new DBSportStoreEntities();

        // GET: Products
        public ActionResult Index(string category, int? page, double min = double.MinValue, double max = double.MaxValue)
        {
            int pageSize = 4;
            int pageNum = (page ?? 1);
            if (category == null)
            {
                var productList = db.Products.OrderByDescending(x => x.NamePro);
                return View(productList.ToPagedList(pageNum, pageSize));
            }
            else
            {
                var productList = db.Products.OrderByDescending(x => x.NamePro).Where(x => x.Category == category);
                return View(productList);
            }
            //return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        [HttpGet]
        public ActionResult Create()
        {
            List<Category> list = db.Categories.ToList();
            ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", "");
            Product p = new Product();
            return View(p);
        }
        public ActionResult SelectCate()
        {
            Category se_cate = new Category();
            se_cate.ListCate = db.Categories.ToList<Category>();
            return PartialView(se_cate);
        }



        [HttpPost]
        public ActionResult Create(Product pro)
        {
            List<Category> list = db.Categories.ToList();
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename = filename + extent;
                    pro.ImagePro = "~/Content/images/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), filename));

                }
                ViewBag.listCategory = new SelectList(list, "IDCate", "NameCate", 1);

                db.Products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Ex_MethodSyntaxlinQ(string _name)
        {
            var query = db.Products.Where(s => s.DecriptionPro.Contains(_name))
                        .Select(s => s)
                        .OrderBy(s => s.NamePro)
                        ;
            return View(query);
        }
        public ActionResult EX_QuerySyntax()
        {
            List<Product> prolist = db.Products.ToList();
            var query = from p in prolist
                        where p.DecriptionPro == "abc"
                        select new ViewModel
                        {
                            Namepro = p.NamePro,
                            DesPro = p.DecriptionPro
                        };
            return View(query.ToList());
        }
        public ActionResult Query_Pro_Cate()
        {
            List<Product> proList = db.Products.ToList();
            List<Category> cateList = db.Categories.ToList();
            var query = from cate in cateList
                        join pro in proList on cate.IDCate equals pro.Category into tbl
                        select new ViewModel
                        {
                            NameCate = cate.NameCate,
                            ListProduct = from p in tbl
                                          select p
                        };
            return View(query.ToList());
        }
    }
}
