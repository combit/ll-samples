package prtloop;

import javax.swing.*;

/**
 * <p>Title: List & Label Sample</p>
 * <p>Description: List & Label Sample</p>
 * <p>Copyright: Copyright (C) combit GmbH</p>
 * <p>Company: combit GmbH</p>
 * @author combit GmbH
 * @version 30.0
 */

public class prtloop
{
  public static void main(String[] args)
  {
    try
    {
      UIManager.setLookAndFeel(UIManager.getSystemLookAndFeelClassName()); // system-default
    }
    catch(Exception e)
    {
    }
    
    prtloopApplication app = new prtloopApplication();
    app.setVisible(true);
  }
}
