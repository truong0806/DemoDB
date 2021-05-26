﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB.Models;
namespace DemoDB.Controllers
{
    public class ShoppingCartController : Controller
    {
        DBSportStoreEntities db = new DBSportStoreEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowCart()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("ShowCart", "ShoppingCart");
            Cart _cart = Session["Cart"] as Cart;
            return View(_cart);
        }
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if(cart==null||Session["Cart"]==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id)
        {
            var _pro = db.Products.SingleOrDefault(s => s.ProductID == id);
            if(_pro!=null)
            {
                GetCart().Add_Product_Cart(_pro);
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult Update_Cart_Quanlity(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int id_pro = int.Parse(form["idPro"]);
            int _quantity = int.Parse(form["cartQuantity"]);
            cart.Update_quantity(id_pro, _quantity);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove_CartItem(id);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public PartialViewResult BagCart()
        {
            int toltal_quantity_item = 0;
            Cart cart = Session["Cart"] as Cart;
            if (cart != null)
                toltal_quantity_item = cart.Total_quantity();
            ViewBag.QuantityCart = toltal_quantity_item;
            return PartialView("BagCart");
        }
        public ActionResult CheckOut(FormCollection form)
        {
            try
            {
                //Cart cart = Session["Cart"] as Cart;
                //OrderPro _order = new OrderPro();
                //_order.DateOrder = DateTime.Now;
                //_order.AddressDeliverry = form["AddressDelivery"];
                //_order.IDCus = int.Parse(form["CodeCustomer"]);
                //db.OrderProes.Add(_order);
                //foreach(var item in cart.Items)
                //{
                //    OrderDetail _order_detail = new OrderDetail();
                //    _order_detail.IDOrder = _order.ID;
                //    _order_detail.IDProduct = item._product.ProductID;
                //    _order_detail.UnitPrice = (double)item._product.Price;
                //    _order_detail.Quantity = item._quantity;
                //    db.OrderDetails.Add(_order_detail);

                //    foreach(var p in db.Products.Where(s=>s.ProductID==_order_detail.IDProduct))
                //    {
                //        var update_quan_pro = p.Quantity - item._quantity;
                //        p.Quantity = update_quan_pro;
                //    }    
                //}
                //db.SaveChanges();
                //cart.ClearCart();
                return RedirectToAction("Đặt hàng thành công", "ShoppingCart");
            }
            catch
            {
                return Content("Lỗi, vui lòng kiểm tra lại");
            }
        }
        public ActionResult CheckOut_Success()
        {
            return View();
        }
    }
}