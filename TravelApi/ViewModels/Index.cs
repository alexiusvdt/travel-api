// namespace goes here

public IActionResult Index(string message)
{
  ViewBag.Message = message;
  return View();
}

[HttpPost]
public IActionResult Index(string username, string password)
{
  if ((username != "secret") || (password != "secret"))
  {
    return View((object) "Login failed");
  
    var accessToken = GenerateJSONWebToken();
    SetJWTCookie(accessToken);

    return RedirectToAction("Index")
  }
}