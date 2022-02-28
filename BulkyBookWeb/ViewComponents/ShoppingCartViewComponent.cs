using System.Security.Claims;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Util;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.ViewComponents;

public class ShoppingCartViewComponent : ViewComponent
{
    private readonly IUnitOfWork _unitOfWork;
    public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
    {
        _unitOfWork= unitOfWork;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        if (claim != null)
        {
            if (HttpContext.Session.GetInt32(SD.SessionShoppingCart) != null)
            {
                return View(HttpContext.Session.GetInt32(SD.SessionShoppingCart));
            }
            else
            {
                HttpContext.Session.SetInt32(SD.SessionShoppingCart,
                    _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == claim.Value).ToList().Count);
                return View(HttpContext.Session.GetInt32(SD.SessionShoppingCart));
            }
        }
        else
        {
            HttpContext.Session.Clear();
            return View(0);
        }
    }
}