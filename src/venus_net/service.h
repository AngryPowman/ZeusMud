#ifndef __SERVICE_H__
#define __SERVICE_H__

#include <string>

namespace Venus
{
    class Service
    {
    public:
        Service(const std::string& service_name);
        virtual ~Service();

    public:
        virtual void initialize() = 0;
        virtual void destroy() = 0;
    };
}

#endif // !__SERVICE_H__
