import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
public class ExampleUsage {
    private static final Logger logger = LoggerFactory.getLogger(ExampleUsage.class);

    public static void main(String[] args) {
        FacebookClient facebookClient = new FacebookClient();
        Google2Client google2Client = new Google2Client();

        // Use the logger at the DEBUG level
        logger.debug("FacebookClient and Google2Client have been initialized.");

        performOAuthOperations(facebookClient, google2Client);
    }
    private static void performOAuthOperations(FacebookClient facebookClient, Google2Client google2Client) {
        logger.debug("Performing OAuth operations...");
    }
}
