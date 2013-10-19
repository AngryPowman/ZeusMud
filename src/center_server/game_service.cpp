#include "game_service.h"
#include <Poco/Data/Common.h>
#include <Poco/Data/SQLite/Connector.h>
#include <Poco/Logger.h>
#include <Poco/FileChannel.h>
#include "game_database_session.h"
#include "global_instance.h"

#define CHECK_INITIALIZE(result, x, s) \
    if (result) \
        std::cout << x << std::endl; \
    else \
        std::cout << s << std::endl;


GameService::GameService()
{
}

GameService::~GameService()
{
}


bool GameService::initialize()
{
    try
    {
        CHECK_INITIALIZE(initPocoLogger(), "Server logger initialize OK.", "Server logger initialize failed.");
        CHECK_INITIALIZE(registerDatabase(), "Database registered OK.", "Database register failed.");
    }
    catch (...)
    {
        std::cout << "An unknown exception occured when initialize game service. Aborted." << std::endl;
        return false;
    }

    return true;
}

void GameService::destroy()
{
    unregisterDatabase();
}

bool GameService::initPocoLogger()
{
    Poco::AutoPtr<Poco::FileChannel> pChannel(new Poco::FileChannel);
    pChannel->setProperty("path", "server.log");
    pChannel->setProperty("rotation", "2 K");
    pChannel->setProperty("archive", "timestamp");

    Poco::Logger::root().setChannel(pChannel);

    //g_Logger = Poco::Logger::get("ServerLogger");

    return true;
}

bool GameService::registerDatabase()
{
    Poco::Data::SQLite::Connector::registerConnector();
    return true;
}

void GameService::unregisterDatabase()
{
    Poco::Data::SQLite::Connector::unregisterConnector();
}