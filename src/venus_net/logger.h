#ifndef __LOGGER_H__
#define __LOGGER_H__

#include "singleton.h"
#include <Poco/Logger.h>
#include <Poco/FileChannel.h>

class Logger
    : public Venus::Singleton<Logger>
{
protected:
    Logger(const std::string& logger);
    virtual ~Logger();

private:
    Poco::Logger _logger;
};

class FileChannelLogger
    : public Logger
{
public:
    FileChannelLogger(const std::string& logger);
    virtual ~FileChannelLogger();
};

#endif // !__LOGGER_H__
