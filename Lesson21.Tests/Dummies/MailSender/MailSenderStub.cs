using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson21.Tests.Dummies.MailSender;
public class MailSenderStub
{
    public bool Send(object data) {
        return true;
    }
}
